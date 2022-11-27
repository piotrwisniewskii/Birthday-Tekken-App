using BirthdayTekken.Models;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
namespace BirthdayTekken.Repository
{
    public class ParticipantsJsonFileRepository : IParticipantsRepository
    {
        private const string _filename = "birthdayTekken.json";

        public void Create(Participants participant)
        {
            var participants = GetParticipantsList();
            var highestId = participants.Any() ? participants.Max(p => p.Id) : 0;
            participant.Id = highestId + 1;
            participants.Add(participant);
            SaveToFile(participants);

        }

        public void Delete(int id)
        {
            var participants = GetParticipantsList();
            var participantsToDelete = participants.First(p => p.Id == id);
            participants.Remove(participantsToDelete);
            SaveToFile(participants);

        }
        public void Update(Participants participant)
        {
            var participants = GetParticipantsList();
            var participantsToUpdate = participants.First(p => p.Id == participant.Id);
            participantsToUpdate.Name = participant.Name;
            participantsToUpdate.Surname = participant.Surname;
            participantsToUpdate.Champion = participant.Champion;
            participantsToUpdate.TournamentsWon = participant.TournamentsWon;
            SaveToFile(participants);

        }

        public ReadOnlyCollection<Participants> GetAll()
        {
            return new ReadOnlyCollection<Participants>(GetParticipantsList());
        }

        private List<Participants> GetParticipantsList()
        {
            string jsonReadText = File.ReadAllText(_filename);
            if (jsonReadText != null && jsonReadText.Length > 0)
            {
                var players = JsonSerializer.Deserialize<List<Participants>>(jsonReadText);
                return players;
            }
            else
            {
                return new List<Participants>();
            }
        }

        public void SaveToFile(List<Participants> participants)
        {
            string participantJson = JsonSerializer.Serialize(participants);
            File.WriteAllText(_filename, participantJson);
        }
    }
}
