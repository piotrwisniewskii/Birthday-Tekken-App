using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface IParticipantService
    {
         Task <IEnumerable<Participant>> GetAllAsync();
         Participant GetById(int id);
         void Add(Participant participant);
         void Update(int id, Participant model);
         void Delete(int id);
    }
}
