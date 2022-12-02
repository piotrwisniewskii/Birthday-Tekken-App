namespace BirthdayTekken.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public DateTime TournamentDate { get; set; }

        public Participants Winner { get; set; }

        public int PlayersNumber { get; set; }
    }
}
