using BirthdayTekken.Models;
using BirthdayTekken.Repository;

namespace BirthdayTekken.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private IParticipantsRepository _participantsRepository;
        public List<Participants> GetAllParticipants()
        {
            return new List<Participants>(_participantsRepository.GetAll());
        }

        public Participants GetById(int id)
        {
            return _participantsRepository.GetAll().FirstOrDefault(p => p.Id == id);
        }
        public void Create(Participants participant)
        {
            _participantsRepository.Create(participant);
        }

        private int GetNextId()
        {
            _idCounter++;
            return _idCounter;
        }

        public void Update(Participants model)
        {
            var participant = GetById(model.Id);
            participant.Name = model.Name;
            participant.Surname = model.Surname;
            participant.Champion = model.Champion;
            participant.TournamentsWon = model.TournamentsWon;
        }
        public void Delete(int id)
        {
            var participant = GetById(id);
            _participants.Remove(participant);
        }

    }


}
