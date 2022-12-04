using BirthdayTekken.Models;
using System.Collections.ObjectModel;

namespace BirthdayTekken.Repository
{
    public interface ITournamentRepository
    {
        public ReadOnlyCollection<Tournament> GetAll();
        public void Create(Tournament tournament,Participants winner);
        public void Update(Tournament tournament);
        public void Delete(int id);
    }
}
