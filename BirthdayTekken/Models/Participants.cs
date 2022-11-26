using BirthdayTekken.Enums;

namespace BirthdayTekken.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Champion Champion { get; set; }
        public int TournamentsWon { get; set; }
    }
}
