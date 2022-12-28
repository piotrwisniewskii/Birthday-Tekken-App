using BirthdayTekken.Enums;
using System.ComponentModel.DataAnnotations;

namespace BirthdayTekken.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Display(Name= "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide surName")]
        [StringLength(25)]
        public string Surname { get; set; }
        [Display(Name = "Favorite Champion")]
        public Champion Champion { get; set; }
        [Display(Name = "Tournaments won")]
        [Range(0, 100, ErrorMessage = "Please provide value from 1 to 100")]
        public int TournamentsWon { get; set; }

        //RelationShips
        public List<Participant_Tournament> Participant_Tournaments { get; set; }
    }
}
