using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TournamentMatchesViewModel
{
    public List<Tournament> AllTournaments { get; set; }
    public SelectList TournamentList => new SelectList(AllTournaments, "Id", "Name");
    public int SelectedTournamentId { get; set; }

    public Tournament SelectedTournament { get; set; }
    public List<NewMatchVm> Matches { get; set; }
}
