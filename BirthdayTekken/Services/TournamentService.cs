using BirthdayTekken.Models;
using BirthdayTekken.Repository;

namespace BirthdayTekken.Services
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _tournamentRepository;
        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
        public void Create(Tournament tournament, Participants winner)
        {
            _tournamentRepository.Create(tournament,winner);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
