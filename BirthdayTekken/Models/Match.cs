using BirthdayTekken.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BirthdayTekken.Models
{
    public class Match : IEntityBase
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }

        public List<Participant_Match> Participant_Matches { get; set; }

        [NotMapped]
        public int WinnerId { get; set; }

    }
}
