using AutoMapper;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        private readonly Random _random;
        private readonly IMapper _mapper;
        private readonly ILogger<TournamentController> _logger;
        private readonly ITournamentService _tournamentService;
        private readonly IParticipantService _participantService;

        public MatchController(Random random,
            IMatchService service,
            IMapper mapper,
            ILogger<TournamentController> logger,
            ITournamentService tournamentService,
            IParticipantService participantService)
        {
            _random = random;
            _service = service;
            _mapper = mapper;
            _logger = logger;
            _tournamentService = tournamentService;
            _participantService = participantService;
        }

        public async Task<IActionResult> Index()
        {
            var matches = await _service.GetAllMatchesAsync();
            ViewBag.Matches = matches.ToList();
            return View(matches);
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetMatchByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> TournamentLadder()
        {
            var matches = await _service.GetAllMatchesAsync();
            var tournaments = await _tournamentService.GetAllAsync();

            var newMatchVms = _mapper.Map<List<NewMatchVm>>(matches);
            var tournamentMatchesViewModel = new TournamentMatchesViewModel
            {
                AllTournaments = _mapper.Map<List<Tournament>>(tournaments),
                Matches = newMatchVms
            };

            return View(tournamentMatchesViewModel);
        }

        public async Task<ActionResult> MakeTournamentLadder()
        {
            await _service.MakeTournamentLadder();
            var matches = await _service.GetAllMatchesAsync();
            var newMatchVms = _mapper.Map<List<NewMatchVm>>(matches);
            return View(newMatchVms);
        }

        public async Task<IActionResult> SelectWinners(int tournamentId,int roundNumber)
        {
            var matches = await _service.GetMatchesForSelectionAsync(roundNumber);
            var matchViewModels = _mapper.Map<List<NewMatchVm>>(matches);

            var winners = matches.Select(m => new WinnerSelectionVM { MatchId = m.Id }).ToList();

            var viewModel = new TournamentMatchesViewModel
            {
                Matches = matchViewModels,
                Winners = winners,
                RoundNumber = roundNumber,
                SelectedTournamentId = tournamentId,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> SelectedTournemantWithMatches(int selectedTournamentId)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(selectedTournamentId);
            var roundNumber = await _service.GetCurrentRoundNumber(selectedTournamentId);

            return RedirectToAction("SelectWinners", new { tournamentId = selectedTournamentId, roundNumber });
        }



        [HttpPost]
        public async Task<IActionResult> CreateNextRound(TournamentMatchesViewModel viewModel)
        {

            await _service.CreateNextRound(viewModel.Winners, viewModel.RoundNumber);


            return RedirectToAction("SelectedTournemantWithMatches", new { selectedTournamentId = viewModel.SelectedTournamentId, roundNumber = viewModel.RoundNumber + 1 });

        }


    }
}

