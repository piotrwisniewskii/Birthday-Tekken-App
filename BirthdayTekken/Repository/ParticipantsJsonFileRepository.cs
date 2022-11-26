﻿using BirthdayTekken.Models;
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
            string participantsJson = JsonSerializer.Serialize(participants);
            File.WriteAllText(_filename, participantsJson);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Participants participant)
        {
            throw new NotImplementedException();
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
    }
}
