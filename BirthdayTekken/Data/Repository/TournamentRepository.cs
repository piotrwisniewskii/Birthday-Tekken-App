using BirthdayTekken.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace BirthdayTekken.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private const string _filename = "tournamentTekken.json";
        private const string _participants = "birthdayTekken.json";

        public void Create(Tournament tournament)
        {
            var tournaments = GetTournamentList();
            var highestId = tournaments.Any() ? tournaments.Max(p => p.Id) : 0;
            tournaments.Add(tournament);
            SaveToFile(tournaments);
        }

        public void Delete(int id)
        {
            var tournaments = GetTournamentList();
            var tournamentToDelete = tournaments.First(p => p.Id == id);
            tournaments.Remove(tournamentToDelete);
            SaveToFile(tournaments);
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

        public ReadOnlyCollection<Participant> GetAllParticipants()
        {
            return new ReadOnlyCollection<Participant>(GetParticipantsList());
        }

        private List<Participant> GetParticipantsList()
        {
            string jsonReadText = File.ReadAllText(_participants);
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

        public void SaveToFile(List<Tournament> tournaments)
        {
            string tournamentJson = JsonSerializer.Serialize(tournaments);
            File.WriteAllText(_filename, tournamentJson);
        }
    }
}
