using BirthdayTekken.Models;
using BirthdayTekken.Repository;
using System.Reflection;

namespace BirthdayTekken.Services
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _tournamentRepository;
        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
        // walidacja participant Id
        public void Create(Tournament tournament)
        {
            _tournamentRepository.Create(tournament);
        }

        public void Delete(int id)
        {
            _tournamentRepository.Delete(id);

        }

        public List<Tournament> GetAll()
        {
            return new List<Tournament>(_tournamentRepository.GetAll()); ;
        }

        public Tournament GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tournament model)
        {
            throw new NotImplementedException();
        }
    }
}
