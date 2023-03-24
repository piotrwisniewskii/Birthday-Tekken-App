using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BirthdayTekken.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Guid RoundNumber { get; set; }

        public List<Participant_Match> ParticipantsMatch { get; set; } = new List<Participant_Match>();

        [NotMapped]
        public Participant? Winner { get; set; }

    }
}
