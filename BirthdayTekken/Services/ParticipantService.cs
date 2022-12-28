using BirthdayTekken.Models;
using BirthdayTekken.Repository;
using BirthdayTekken.Services;
using System.Collections.ObjectModel;
using BirthdayTekken.Enums;
namespace BirthdayTekken.Services
{
    public class ParticipantService : IParticipantService
    {

        private IParticipantRepository _participantsRepository;
        public ParticipantService(IParticipantRepository participantsRepository)
        {
            _participantsRepository = participantsRepository;
        }

        public List<Participant> GetAllParticipants()
        {
            return new List<Participant>(_participantsRepository.GetAll());
        }

        public Participant GetById(int id)
        {
            return _participantsRepository.GetAll().FirstOrDefault(p => p.Id == id);
        }
        public void Create(Participant participant)
        {
            _participantsRepository.Create(participant);
        }


         public void Update(Participant model)
        {
            _participantsRepository.Update(model);
        }
        public void Delete(int id)
        {
            _participantsRepository.Delete(id);
        }

    }


}
