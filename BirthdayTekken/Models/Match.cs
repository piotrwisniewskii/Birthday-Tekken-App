using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BirthdayTekken.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }

        public List<Participant> Participants { get; set; }

        [NotMapped]
        public Participant? Winner { get; set; }

    }
}
