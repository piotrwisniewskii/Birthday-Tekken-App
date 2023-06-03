using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Data.Base
{
    public interface IMatchRepository : IEntityBaseRepository<Match>
    {
        Task AddNewMatchAsync(NewMatchVm newMatchVm);
    }
}
