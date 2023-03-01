using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Models
{
    public class Participant_MatchMaker
    {
        public int MatchMakerId { get; set; }
        public MatchMaker MatchMaker { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
