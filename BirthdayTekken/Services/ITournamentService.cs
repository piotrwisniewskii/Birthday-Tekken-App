using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface ITournamentService
    {
        public List<Tournament> GetAll();
        public Tournament GetById(int id);
        public void Create(Tournament participant);
        public void Update(Tournament model);
        public void Delete(int id);
    }
}
