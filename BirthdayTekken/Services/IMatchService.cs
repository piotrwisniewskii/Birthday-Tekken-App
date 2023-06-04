using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Services
{
    public interface IMatchService : IEntityBaseRepository<Match>
    {
        Task<List<Match>> GetAllMatchesAsync();
        Task<List<Match>> GetMatchesForSelectionAsync(int roundNumber);
        Task CreateNextRound(List<WinnerSelectionVM> winnerSelections, int roundnumber);
        Task<List<Match>> GetMatchesByTournamentIdAsync(int tournamentId);
        Task<int> GetCurrentRoundNumber(int tournamentId);
        Task DeleteAll();

    }
}
