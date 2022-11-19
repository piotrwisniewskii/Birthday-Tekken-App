using BirthdayTekken.Models;

namespace BirthdayTekken.Services
{
    public class ParticipantsService
    {
        private static int _idCounter = 2;
        private static List<Participants> _participants =
            new List<Participants>
            {
                new Participants
                {
                    Id = 1,
                    Name = "Piotr",
                    Surname = "Wiśniewski",
                    FavoriteChamp = "Jhin",
                    TimesChampion = 1
                }
            };
        public List<Participants> GetAll()
        {
            return _participants;
        }

        public Participants GetById(int id)
        {
            return _participants.FirstOrDefault(p => p.Id == id);
        }
        public void Create(Participants participant)
        {
            participant.Id = GetNextId();
            _participants.Add(participant);
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
            participant.FavoriteChamp = model.FavoriteChamp;
            participant.TimesChampion = model.TimesChampion;
        }

    }


}
