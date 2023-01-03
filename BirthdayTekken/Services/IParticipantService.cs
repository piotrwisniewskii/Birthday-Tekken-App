using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface IParticipantService
    {
         Task <IEnumerable<Participant>> GetAllAsync();
         Task<Participant> GetByIdAsync(int id);
         Task AddAsync(Participant participant);
         void Update(int id, Participant model);
         void Delete(int id);
    }
}
