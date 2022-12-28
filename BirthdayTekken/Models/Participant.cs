using BirthdayTekken.Enums;
using System.ComponentModel.DataAnnotations;

namespace BirthdayTekken.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [StringLength(25)]
        public string Surname { get; set; }
        public Champion Champion { get; set; }
        [Range(0, 100, ErrorMessage = "Please provide value from 1 to 100")]
        public int TournamentsWon { get; set; }

        //RelationShips
        public List<Participant_Tournament> Participant_Tournaments { get; set; }
    }
}
