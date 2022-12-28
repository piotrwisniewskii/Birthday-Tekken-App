using BirthdayTekken.Models;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
namespace BirthdayTekken.Repository
{
    public class ParticipantJsonFileRepository : IParticipantRepository
    {
        private const string _filename = "birthdayTekken.json";

        public void Create(Participant participant)
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
        public void Update(Participant participant)
        {
            var participants = GetParticipantsList();
            var participantsToUpdate = participants.First(p => p.Id == participant.Id);
            participantsToUpdate.Name = participant.Name;
            participantsToUpdate.Surname = participant.Surname;
            participantsToUpdate.Champion = participant.Champion;
            participantsToUpdate.TournamentsWon = participant.TournamentsWon;
            SaveToFile(participants);

        }

        public ReadOnlyCollection<Participant> GetAll()
        {
            return new ReadOnlyCollection<Participant>(GetParticipantsList());
        }

        private List<Participant> GetParticipantsList()
        {
            string jsonReadText = File.ReadAllText(_filename);
            if (jsonReadText != null && jsonReadText.Length > 0)
            {
                var players = JsonSerializer.Deserialize<List<Participant>>(jsonReadText);
                return players;
            }
            else
            {
                return new List<Participant>();
            }
        }

        public void SaveToFile(List<Participant> participants)
        {
            string participantJson = JsonSerializer.Serialize(participants);
            File.WriteAllText(_filename, participantJson);
        }

        public Participant GetById(int id)
        {
            return GetAll().Where(p => p.Id == id).Single();
        }
    }
}
