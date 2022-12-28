using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface IParticipantService
    {
        public List<Participant> GetAllParticipants();
        public Participant GetById(int id);
        public void Create(Participant participant);
        public void Update(Participant model);
        public void Delete(int id);
    }
}
