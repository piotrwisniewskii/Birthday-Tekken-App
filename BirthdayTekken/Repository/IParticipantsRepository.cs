using BirthdayTekken.Models;
using System.Collections.ObjectModel;

namespace BirthdayTekken.Repository
{
    public interface IParticipantsRepository
    {

        public ReadOnlyCollection<Participants> GetAll();
        public void Create(Participants participant);
        public void Update(Participants participant);
        public void Delete(int id);

    }
}
