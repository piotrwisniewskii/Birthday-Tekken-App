using BirthdayTekken.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayTekken.Models
{
    public class Match : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int RoundNumber { get; set; }


        public int WinnerId { get; set; }

        [ValidateNever]
        public List<Participant_Match> Participant_Matches { get; set; }
    }
}
