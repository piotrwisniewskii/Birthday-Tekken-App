using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BirthdayTekken.Models.ViewModel
{
    public class NewMatchMakerVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Winner")]
        public int? WinnerId { get; set; }
        [Required]

        //Relationships
        [ValidateNever]
        public List<int> ParticipantsIds { get; set; }
    }
}
