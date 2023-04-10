using BirthdayTekken.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayTekken.Models
{
    public class Match : IEntityBase
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }

        public List<Participant_Match> Participant_Matches { get; set; } = new List<Participant_Match>();

        [NotMapped]
        public int WinnerId { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
       

    }
}