namespace BirthdayTekken.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public DateTime TournamentDate { get; set; }

        public int WinnerId { get; set; }
        public int PlayersNumber { get; set; }
    }
}
