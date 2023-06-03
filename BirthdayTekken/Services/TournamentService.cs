using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Services
{
    public class TournamentService : EntityBaseRepository<Tournament>, ITournamentService
    {
        private readonly AppDbContext _context;
        private readonly IMatchRepository _matchRepo;
        public TournamentService(AppDbContext context, IMatchRepository matchRepo) : base(context)
        {
            _context = context;
            _matchRepo = matchRepo;
        }
        public async Task AddNewTournamentAsync(NewTournamentVM data)
        {
            var newTournament = new Tournament()
            {
                Name = data.Name,
                TournamentDate = data.TournamentDate,
                WinnerId = data.WinnerId,
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

        public async Task MakeSelectedTournamentLadder(int tournamentId, List<int> selectedParticipantIds)
        {
            var tournament = await GetTournamentByIdAsync(tournamentId);
            var participants = await _context.Participants
                .Where(p => selectedParticipantIds.Contains(p.Id))
                .ToListAsync();

            if (participants.Count < 2)
            {
                throw new InvalidOperationException("There should be at least 2 participants in the database.");
            }

            var random = new Random();
            participants = participants.OrderBy(p => random.Next()).ToList();

            var matches = new List<NewMatchVm>();

            while (participants.Count > 1)
            {
                var participant1 = participants[0];
                var participant2 = participants[1];
                participants.RemoveRange(0, 2);

                var newMatch = new NewMatchVm()
                {
                    RoundNumber = 1,
                    WinnerId = 0,
                    TournamentId = tournamentId,
                    ParticipantsIds = new List<int> { participant1.Id, participant2.Id }
                };

                matches.Add(newMatch);
            }

            if (participants.Count == 1)
            {
                // Participant receives a bye round
                var byeMatch = new NewMatchVm()
                {
                    RoundNumber = 1,
                    WinnerId = 0,
                    TournamentId = tournamentId,
                    ParticipantsIds = new List<int> { participants[0].Id, participants[0].Id }
                };

                matches.Add(byeMatch);
            }

            foreach (var match in matches)
            {
                await _matchRepo.AddNewMatchAsync(match);
            }
        }
    }

}

