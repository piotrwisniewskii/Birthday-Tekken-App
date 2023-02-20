using BirthdayTekken.Models.ViewModel;

namespace BirthdayTekken.Models
{
    public class Participant_Tournament
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }


        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int MatchMakerId { get; set; }
        public MatchMaker MatchMaker { get; set; }
    }
}
