using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using System.Linq.Expressions;

namespace BirthdayTekken.Services
{
    public interface IMatchService : IEntityBaseRepository<Match>
    {
        Task<Match> GetMatchByIdAsync(int id);
        Task AddNewMatchAsync(NewMatchVm data);
        Task<NewMatchDropdownsVM> GetNewMatchDropdownsValies();
        Task<NewMatchDropdownsVM> GetRandomizedParticipantsList();
        Task RemoveParticipantAsync(int participantId);
        Task AddRandomMatchAsync();
        Task<List<Match>> GetAllMatchesAsync();
        Task MakeTournamentLadder();
        Task<List<Match>> GetMatchesForSelectionAsync(int roundNumber);

    }
}
