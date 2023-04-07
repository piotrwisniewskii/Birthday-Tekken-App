namespace BirthdayTekken.Models
{
    public class Participant_Match
    {

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
