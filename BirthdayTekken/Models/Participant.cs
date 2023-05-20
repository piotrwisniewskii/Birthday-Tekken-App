using BirthdayTekken.Data.Base;
using BirthdayTekken.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayTekken.Models
{
    public class Participant : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public byte[] ProfilePicture { get; set; }

        [Display(Name = "Profile Picture file")]
        [NotMapped]
        public IFormFile ProfilePictureFile { get; set; }

        [Required(ErrorMessage = "Please provide a profile picture")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please provide Champion")]
        [Display(Name = "Favorite Champion")]
        public Champion Champion { get; set; }

        [Display(Name = "Tournaments won")]
        [Range(0, 100, ErrorMessage = "Please provide a value from 0 to 100")]
        [Required(ErrorMessage = "Please provide Tournaments won")]
        public int TournamentsWon { get; set; }

        // Relationships
        [ValidateNever]
        public List<Participant_Tournament> Participant_Tournaments { get; set; }

        [ValidateNever]
        public List<Participant_Match> Participant_Matches { get; set; }
    }
}
