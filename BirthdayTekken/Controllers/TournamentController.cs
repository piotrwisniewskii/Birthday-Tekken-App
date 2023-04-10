using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirthdayTekken.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentService _service;
        public TournamentController(ITournamentService service)
        {
            _service = service;
        }
        // GET: TournamentController
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync(n=>n.Participants_Tournaments);
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetTournamentByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }


        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewTournamentDropdownsValies();
            ViewBag.Participants = new SelectList(movieDropdownsData.Participants,"Id","Name","Surname");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTournamentVM tournament)
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



        public async Task<IActionResult> Edit(int id)
        {
            var tournamentDetails = await _service.GetTournamentByIdAsync(id);
            if(tournamentDetails != null) return View("NotFound");

            var response = new NewTournamentVM()
            {
                Id = tournamentDetails.Id,
                Name = tournamentDetails.Name,
                TournamentDate = tournamentDetails.TournamentDate,
                PlayersNumber = tournamentDetails.PlayersNumber,
                ParticipantsIds = tournamentDetails.Participants_Tournaments.Select(n => n.ParticipantId).ToList(),
            };

            var tournamentDropDownsData = await _service.GetNewTournamentDropdownsValies();
            ViewBag.Participants = new SelectList(tournamentDropDownsData.Participants, "Id", "Name", "Surname");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewTournamentVM tournament)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewTournamentDropdownsValies();

                ViewBag.Participants = new SelectList(movieDropdownsData.Participants, "Id", "Name", "Surname");
                return View(tournament);
            }

            await _service.AddNewTournamentAsync(tournament);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TournamentLadder(int id)
        {
            var model = await _service.GetTournamentByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> MakeSelectedTournamentLadder(int tournamentId, List<int> selectedParticipants)
        {
            try
            {
                await _service.MakeSelectedTournamentLadder(tournamentId, selectedParticipants);
                return RedirectToAction("TournamentLadder", new { id = tournamentId });
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SelectParticipants(int id)
        {
            var tournament = await _service.GetTournamentByIdAsync(id);
            if (tournament == null) return View("NotFound");

            return View("SelectParticipants", tournament);
        }


        [HttpPost]
        public async Task<IActionResult> SelectParticipants(int tournamentId, List<int> selectedParticipants)
        {
            await _service.MakeSelectedTournamentLadder(tournamentId, selectedParticipants);
            return RedirectToAction("Round", new { id = tournamentId });
        }

        public async Task<IActionResult> Round(int id)
        {
            var model = await _service.GetTournamentByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }
    }
}
