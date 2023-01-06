using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface ITournamentService : IEntityBaseRepository<Tournament>
    {
        Task<Tournament> GetTournamentByIdAsync(int id);
    }
}
