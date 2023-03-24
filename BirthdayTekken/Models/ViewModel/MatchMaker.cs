using BirthdayTekken.Data.Base;

namespace BirthdayTekken.Models.ViewModel
{
    public class MatchMaker : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Participant> Round { get; set; }

    }
}
