using BirthdayTekken.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BirthdayTekken.Models
{
    public class Tournament : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }
        [Display(Name = "Winner")]
        [Required]
        public int WinnerId { get; set; }
        [Required]
        public int PlayersNumber { get; set; }

        //Relationships
        [ValidateNever]
        public List<Participant_Tournament> Participants_Tournaments { get; set; }
        public List<Match> Matches {get;set;}
    }
}
