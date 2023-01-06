using BirthdayTekken.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BirthdayTekken.Models
{
    public class Tournament : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
        [Display(Name = "Winner")]
        public int WinnerId { get; set; }
        public int PlayersNumber { get; set; }

        //Relationships
        public List<Participant_Tournament> Participant_Tournaments { get; set; }
    }
}
