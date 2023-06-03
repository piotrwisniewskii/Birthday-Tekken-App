using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Services
{
    public interface ITournamentService : IEntityBaseRepository<Tournament>
    {
        Task<Tournament> GetTournamentByIdAsync(int id);
        Task<NewTournamentDropdownsVM> GetNewTournamentDropdownsValies();
        Task AddNewTournamentAsync(NewTournamentVM data);
        Task MakeSelectedTournamentLadder(int tournamentId, List<int> selectedParticipantIds);
    }
}
