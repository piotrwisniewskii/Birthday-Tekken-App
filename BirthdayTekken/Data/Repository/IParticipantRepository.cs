using BirthdayTekken.Models;
using System.Collections.ObjectModel;

namespace BirthdayTekken.Repository
{
    public interface IParticipantRepository
    {

        public ReadOnlyCollection<Participant> GetAll();
        public void Create(Participant participant);
        public void Update(Participant participant);
        public void Delete(int id);
        public Participant GetById(int id);

    }
}
