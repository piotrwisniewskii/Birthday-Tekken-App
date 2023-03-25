namespace BirthdayTekken.Models.ViewModel
{
    public class Round
    {
        public int Id { get; set; }
        public Round()
        {
        }
        public Round(Participant participant1, Participant participant2)
        {
            Participant1 = participant1;
            Participant2 = participant2;
        }

        public Participant Participant1 { get; set; }
        public Participant Participant2 { get; set; }
        public Participant? Winner { get; set; }
    }
}
