using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Services
{
    public interface IMatchMakerService : IEntityBaseRepository<MatchMaker>
    {
        Task<MatchMaker> GetMatchById(int id);
        Task<NewMatchMakerDropdownsVM> GetParticipantsLIst();
        Task AddNewMatchAsync(NewMatchMakerVM match);
    }
}
