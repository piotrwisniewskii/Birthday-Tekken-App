using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BirthdayTekken.Models.ViewModel
{
    public class NewMatchVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Winner")]
        public int WinnerId { get; set; }

        public int RoundNumber { get; set; }
        [Required]

        //Relationships
        [ValidateNever]
        public List<int> ParticipantsIds { get; set; }


        public NewMatchVm(Participant participant1, Participant participant2)
        {
            Participant1 = participant1;
            Participant2 = participant2;
        }

        public Participant Participant1 { get; set; }
        public Participant Participant2 { get; set; }
        public Participant? Winner { get; set; }
    }
}
