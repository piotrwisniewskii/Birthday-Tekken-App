using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BirthdayTekken.Models.ViewModel
{
    public class NewMatchVm
    {
        public int Id { get; set; }
        [Required]

        [Display(Name = "Winner")]
        public int WinnerId { get; set; }

        public int MatchId { get; set; }

        public int? TournamentId { get; set; }

        public int RoundNumber { get; set; }
        [Required]

        //Relationships
        [ValidateNever]
        public List<int> ParticipantsIds { get; set; }
        public List<string> ParticipantNames { get; set; }
    }
}
