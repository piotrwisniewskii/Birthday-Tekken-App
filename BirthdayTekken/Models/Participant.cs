using BirthdayTekken.Enums;
using System.ComponentModel.DataAnnotations;

namespace BirthdayTekken.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Display(Name= "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please provide Champion")]
        [Display(Name = "Favorite Champion")]
        public Champion Champion { get; set; }

        [Display(Name = "Tournaments won")]
        [Range(0, 100, ErrorMessage = "Please provide value from 1 to 100")]
        [Required(ErrorMessage = "Please provide Tournaments won")]
        public int TournamentsWon { get; set; }
        //RelationShips
        public List<Participant_Tournament> Participant_Tournaments { get; set; }

    }
}
