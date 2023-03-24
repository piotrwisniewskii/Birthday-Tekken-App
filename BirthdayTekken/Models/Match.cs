using System.Numerics;

namespace BirthdayTekken.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Participant Participant1 { get; set; }
        public Participant Participan2t { get; set; }
        public Participant Winner { get; set; }
        public int Participant1Id { get; set; }
        public int Participant2Id { get; set; }
        public int? WinnerId { get; set; }
    }
}
