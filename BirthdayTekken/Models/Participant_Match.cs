namespace BirthdayTekken.Models
{
    public class Participant_Match
    {

        public Match Match { get; set; }
        public int MatchId { get; set; }

        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }
    }
}
