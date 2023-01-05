using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public interface IParticipantService
    {
         Task <IEnumerable<Participant>> GetAllAsync();
         Task<Participant> GetByIdAsync(int id);
         Task AddAsync(Participant participant);
         Task <Participant> UpdateAsync(int id, Participant model);
         Task DeleteAsync(int id);
    }
}
