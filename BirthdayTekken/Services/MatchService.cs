using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Services
{
    public class MatchService : EntityBaseRepository<Match>, IMatchService
    {
        private readonly AppDbContext _context;
        private readonly IMatchRepository _matchRepo;

        public MatchService(AppDbContext context, IMatchRepository matchRepo ) : base(context)
        {
            _context = context;
            _matchRepo = matchRepo;
        }
        public async Task<List<Match>> GetAllMatchesAsync()
        {
            var matches = await _context.Matches
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
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

            var winners = winnerSelections.Select(ws => ws.WinnerId).ToList();
            if (winners.Count % 2 != 0)
            {
                if (winners.Last() == winners.First())
                {
                    winners.RemoveAt(winners.Count - 1);
                }
                else
                {
                    winners.Add(winners.First());
                }
            }

            var random = new Random();
            var shuffledWinners = winners.OrderBy(w => random.Next()).ToList();

            var matches = new List<NewMatchVm>();

            while (shuffledWinners.Count > 1)
            {
                var participant1 = shuffledWinners[0];
                var participant2 = shuffledWinners[1];
                shuffledWinners.RemoveRange(0, 2);

                var newMatch = new NewMatchVm
                {
                    TournamentId = tournamentId,
                    RoundNumber = roundNumber + 1,
                    ParticipantsIds = new List<int> { participant1, participant2 }
                };

                matches.Add(newMatch);
            }

            if (shuffledWinners.Count == 1)
            {
                // Participant receives a bye round by playing against themselves
                var participant = shuffledWinners[0];
                var byeMatch = new NewMatchVm
                {
                    TournamentId = tournamentId,
                    RoundNumber = roundNumber + 1,
                    ParticipantsIds = new List<int> { participant, participant }
                };

                matches.Add(byeMatch);
            }

            foreach (var match in matches)
            {
                await _matchRepo.AddNewMatchAsync(match);
            }
        }

        public async Task<int> GetCurrentRoundNumber(int tournamentId)
        {
            var matches = await GetMatchesByTournamentIdAsync(tournamentId);

            if (!matches.Any())
            {
                return 1;
            }

            var highestRoundNumber = matches.Max(m => m.RoundNumber);

            return highestRoundNumber;
        }


    }
}
