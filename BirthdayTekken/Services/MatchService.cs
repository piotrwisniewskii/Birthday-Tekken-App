using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static BirthdayTekken.Models.ViewModel.WinnerSelectionVM;

namespace BirthdayTekken.Services
{
    public class MatchService : EntityBaseRepository<Match>, IMatchService
    {
        private readonly AppDbContext _context;

        public MatchService(AppDbContext context) : base(context)
        {
            _context = context;
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
            }).ToList();

            newMatch.Participant_Matches = participantMatches;

            _context.Participants_Matches.AddRange(participantMatches);
            await _context.SaveChangesAsync();
        }
        public async Task<Match> GetMatchByIdAsync(int id)
        {
            var matchDetails = await _context.Matches
                .Include(am => am.Participant_Matches)
                .ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return matchDetails;
        }

        public async Task<NewMatchDropdownsVM> GetNewMatchDropdownsValies()
        {
            var response = new NewMatchDropdownsVM()
            {
                Participants = await _context.Participants
                .OrderBy(n => n.Name)
                .ToListAsync()
            };

            return response;
        }

        public async Task<NewMatchDropdownsVM> GetRandomizedParticipantsList()
        {
            Random random = new Random();

            var participants = await _context.Participants.ToListAsync();

            var response = new NewMatchDropdownsVM()
            {
                Participants = participants
                    .OrderBy(p => random.Next())
                    .ToList()
            };

            return response;
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            var matches = await _context.Matches
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
        }


        public async Task MakeTournamentLadder()
        {
            var participants = await GetRandomizedParticipantsList();

            if (participants.Participants.Count < 2)
            {
                throw new InvalidOperationException("There should be at least 2 participants in the database.");
            }

            if (participants.Participants.Count % 2 != 0)
            {
                throw new InvalidOperationException("The number of participants should be even.");
            }

            int numberOfMatches = participants.Participants.Count / 2;

            for (int i = 0; i < numberOfMatches; i++)
            {
                var participant1 = participants.Participants[i * 2];
                var participant2 = participants.Participants[i * 2 + 1];

                var newMatch = new NewMatchVm()
                {
                    RoundNumber = 1,
                    WinnerId = 0,
                    ParticipantsIds = new List<int> { participant1.Id, participant2.Id }
                };

                await AddNewMatchAsync(newMatch);
            }
        }

        public async Task<List<Match>> GetMatchesForSelectionAsync(int roundNumber)
        {
            var matches = await _context.Matches
                .Where(m => m.RoundNumber == roundNumber)
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
        }

        public async Task<List<Match>> GetMatchesByTournamentIdAsync(int tournamentId)
        {
            var matches = await _context.Matches
                .Where(m => m.TournamentId == tournamentId)
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
        }


        public async Task CreateNextRound(List<WinnerSelectionVM> winnerSelections, int roundNumber)
        {
            if (!winnerSelections.Any())
            {
                throw new Exception("No winners provided to create the next round.");
            }

            var tournamentId = winnerSelections.First().TournamentId;

            var winnerIds = winnerSelections.Select(ws => ws.WinnerId).ToList();
            if (winnerIds.Count % 2 != 0)
            {
                throw new Exception("The number of winners must be even to create the next round.");
            }

            var winnerPairs = new List<(int, int)>();

            for (int i = 0; i < winnerIds.Count; i += 2)
            {
                var pair = (winnerIds[i], winnerIds[i + 1]);
                winnerPairs.Add(pair);
            }

            foreach (var pair in winnerPairs)
            {
                var newMatch = new NewMatchVm
                {
                    TournamentId = tournamentId,
                    RoundNumber = roundNumber + 1,
                    ParticipantsIds = new List<int> { pair.Item1, pair.Item2 }

                };

                await AddNewMatchAsync(newMatch);
            }
        }


        public async Task<int> GetCurrentRoundNumber(int tournamentId)
        {
            var matches = await GetMatchesByTournamentIdAsync(tournamentId);

            if (!matches.Any())
            {
                // No matches found, return the initial round number (e.g., 1)
                return 1;
            }

            var highestRoundNumber = matches.Max(m => m.RoundNumber);

            return highestRoundNumber;
        }


    }
}
