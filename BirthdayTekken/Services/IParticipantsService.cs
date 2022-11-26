using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface IParticipantsService
    {
        public List<Participants> GetAllParticipants();
        public Participants GetById(int id);
        public void Create(Participants participant);
        public void Update(Participants model);
        public void Delete(int id);
    }
}
