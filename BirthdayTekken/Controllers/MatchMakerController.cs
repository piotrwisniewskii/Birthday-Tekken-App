using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirthdayTekken.Controllers
{
    public class MatchMakerController : Controller
    {
        private readonly ITournamentService _service;

        public MatchMakerController(ITournamentService service)
        {
            _service= service;
        }

        public async Task<IActionResult> ChooseMatch()
        {
            var movieDropdownsData = await _service.GetNewTournamentDropdownsValies();
            ViewBag.Participants = new SelectList(movieDropdownsData.Participants, "Id", "Name", "Surname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChooseMatch(NewTournamentVM tournament)
        {
            if (!ModelState.IsValid)
            {
                var tournamentDropDownsData = await _service.GetNewTournamentDropdownsValies();

                ViewBag.Participants = new SelectList(tournamentDropDownsData.Participants, "Id", "Name", "Surname");
                return View(tournament);
            }

            await _service.AddNewTournamentAsync(tournament);
            return RedirectToAction(nameof(Index));
        }
    }
}
