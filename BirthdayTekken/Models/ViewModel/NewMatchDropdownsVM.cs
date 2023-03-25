namespace BirthdayTekken.Models.ViewModel
{
    public class NewMatchDropdownsVM
    {
        public NewMatchDropdownsVM()
        {
            Participants = new List<Participant>();
        }
        public List<Participant> Participants { get; set; }
    }
}
