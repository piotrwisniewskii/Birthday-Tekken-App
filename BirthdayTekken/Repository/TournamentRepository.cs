﻿using BirthdayTekken.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace BirthdayTekken.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private const string _filename = "tournamentTekken.json";

        public void Create(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Tournament> GetAll()
        {
            return new ReadOnlyCollection<Tournament>(GetTournamentList());
        }

        public void Update(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        private List<Tournament> GetTournamentList()
        {
            string jsonReadText = File.ReadAllText(_filename);
            if(jsonReadText != null && jsonReadText.Length > 0)
            {
                var tournaments = JsonSerializer.Deserialize<List<Tournament>>(jsonReadText);
                return tournaments;
            }
            else
            {
                return new List<Tournament>();
            }
        }

        public void SaveToFile(List<Tournament> tournaments)
        {
            string tournamentJson = JsonSerializer.Serialize(tournaments);
            File.WriteAllText(_filename, tournamentJson);
        }
    }
}
