using BirthdayTekken.Models;
using BirthdayTekken.Repository;
using BirthdayTekken.Services;
using System.Collections.ObjectModel;
using BirthdayTekken.Enums;
namespace BirthdayTekken.Services
{
    public class ParticipantsService : IParticipantsService
    {

        private IParticipantsRepository _participantsRepository;
        public ParticipantsService(IParticipantsRepository participantsRepository)
        {
            _participantsRepository = participantsRepository;
        }

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


         public void Update(Participants model)
        {
            _participantsRepository.Update(model);
        }
        public void Delete(int id)
        {
            _participantsRepository.Delete(id);
        }

    }


}
