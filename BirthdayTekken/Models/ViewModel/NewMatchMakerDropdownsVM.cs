namespace BirthdayTekken.Models.ViewModel
{
    public class NewMatchMakerDropdownsVM
    {
        public NewMatchMakerDropdownsVM()
        {
            Participants = new List<Participant>();
        }
        public List<Participant> Participants { get; set; }
    }
}
