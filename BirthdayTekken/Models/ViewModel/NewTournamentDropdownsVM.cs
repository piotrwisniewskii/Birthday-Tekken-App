namespace BirthdayTekken.Models.ViewModel
{
    public class NewTournamentDropdownsVM
    {
        public NewTournamentDropdownsVM()
        {
            Participants = new List<Participant>();
        }
        public List<Participant> Participants { get; set; }
    }
}
