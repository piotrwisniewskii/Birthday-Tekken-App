namespace BirthdayTekken.Models.ViewModel
{
    public class MatchViewModel
    {
        public int MatchId { get; set; }
        public int RoundNumber { get; set; }
        public Participant Participant1 { get; set; }
        public Participant Participant2 { get; set; }
    }

}
