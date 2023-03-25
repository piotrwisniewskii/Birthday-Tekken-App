using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;

using System.Xml.Linq;

namespace BirthdayTekken.Models.ViewModel
{
    public class NewTournamentVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }

        [Display(Name = "Winner")]
        public int WinnerId { get; set; }
        [Required]
        public int PlayersNumber { get; set; }

        //Relationships
        [ValidateNever]
        public List<int> ParticipantsIds { get; set; }

    }
}

