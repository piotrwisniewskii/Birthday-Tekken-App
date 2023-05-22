using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TournamentMatchesViewModel
{
    private List<Tournament> _allTournaments;

    public List<Tournament> AllTournaments
    {
        get => _allTournaments ?? new List<Tournament>();
        set => _allTournaments = value;
    }

    public SelectList TournamentList => new SelectList(AllTournaments, "Id", "Name");
    public int SelectedTournamentId { get; set; }

    public Tournament SelectedTournament { get; set; }
    public List<NewMatchVm> Matches { get; set; }
    public List<WinnerSelectionVM> Winners { get; set; }
    public int RoundNumber { get; set; }
}
