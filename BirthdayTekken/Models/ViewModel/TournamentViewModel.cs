using BirthdayTekken.Models;
namespace BirthdayTekken.Models.ViewModel
{
    public class TournamentViewModel
    {
        public List<Participant> Participants { get; set; }
        public Tournament TournamentModel { get; set; }
    }
}
