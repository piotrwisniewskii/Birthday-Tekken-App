using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BirthdayTekken.Services
{
    public class TournamentService : EntityBaseRepository<Tournament>, ITournamentService
    {
        private readonly AppDbContext _context;
        public TournamentService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewTournamentAsync(NewTournamentVM data)
        {
            var newTournament = new Tournament()
            {
                Name = data.Name,
                TournamentDate = data.TournamentDate,
                WinnerId = data.WinnerId,
                PlayersNumber = data.PlayersNumber,
            };
            await _context.Tournaments.AddAsync(newTournament);

            await _context.SaveChangesAsync();

            foreach (var participantId in data.ParticipantsIds)
            {
                var newParticipantTournament = new Participant_Tournament()
                {
                    TournamentId = newTournament.Id,
                    ParticipantId = participantId
                };
                await _context.Participants_Tournaments
                        .AddAsync(newParticipantTournament);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewTournamentDropdownsVM> GetNewTournamentDropdownsValies()
        {
            var response = new NewTournamentDropdownsVM()
            {
                Participants = await _context.Participants
                .OrderBy(n => n.Name)
                .ToListAsync()
            };

            return response;
        }

        public async Task<Tournament> GetTournamentByIdAsync(int id)
        {
            var tournamentDetails = await _context.Tournaments
                .Include(am => am.Participants_Tournaments)
                .ThenInclude(a => a.Participant)
                .Include(m => m.Matches)
                .FirstOrDefaultAsync(n => n.Id == id);

            return tournamentDetails;
        }

        public async Task MakeSelectedTournamentLadder(int tournamnetId, List<int> selectedParticipantIds)
        {
            var tournament = await GetTournamentByIdAsync(tournamnetId);
            var participants = await _context.Participants
            .Where(p => selectedParticipantIds.Contains(p.Id))
            .ToListAsync();

            if (participants.Count < 2)
            {
                throw new InvalidOperationException("There should be at least 2 participants in the database.");
            }

            if (participants.Count % 2 != 0)
            {
                throw new InvalidOperationException("The number of participants should be even.");
            }

            var random = new Random();
            participants = participants.OrderBy(p => random.Next()).ToList();

            int numberOfMatches = participants.Count / 2;

            for (int i = 0; i < numberOfMatches; i++)
            {
                var participant1 = participants[i * 2];
                var participant2 = participants[i * 2 + 1];

                var newMatch = new NewMatchVm()
                {
                    RoundNumber = 1,
                    WinnerId = 0,
                    TournamentId = tournamnetId,
                    ParticipantsIds = new List<int> { participant1.Id, participant2.Id }
                };

                await AddNewMatchAsync(newMatch);
            }
        }

        public async Task AddNewMatchAsync(NewMatchVm newMatchVm)
        {
            var newMatch = new Match
            {
                RoundNumber = newMatchVm.RoundNumber,
                WinnerId = newMatchVm.WinnerId,
                TournamentId = newMatchVm.TournamentId,

            };

            _context.Matches.Add(newMatch);
            await _context.SaveChangesAsync();

            var participantMatches = newMatchVm.ParticipantsIds.Select(participantId => new Participant_Match
            {
                MatchId = newMatch.Id,
                ParticipantId = participantId
            });

            _context.Participants_Matches.AddRange(participantMatches);
            await _context.SaveChangesAsync();
        }


    }
}

