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

        public async Task DeleteAll()
        {
             _context.Matches.RemoveRange(_context.Matches);
            await _context.SaveChangesAsync();

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


            var random = new Random();

            var matches = new List<NewMatchVm>();

            if (winners.Count % 2 != 0)
            {
                var winner = winners[0];
                var byeMatch = new NewMatchVm()
                {
                    TournamentId = tournamentId,
                    RoundNumber = roundNumber + 1,
                    ParticipantsIds = new List<int> { winner, winner }
                };

                winners.Remove(winners[0]);
                matches.Add(byeMatch);
            }


            while (winners.Count > 1)
            {
                var participant1 = winners[0];
                var participant2 = winners[1];
                winners.RemoveRange(0, 2);

                var newMatch = new NewMatchVm
                {
                    TournamentId = tournamentId,
                    RoundNumber = roundNumber + 1,
                    ParticipantsIds = new List<int> { participant1, participant2 }
                };

                matches.Add(newMatch);
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
