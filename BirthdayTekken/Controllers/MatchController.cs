using AutoMapper;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        private readonly Random _random;
        private readonly IMapper _mapper;
        private readonly ILogger<TournamentController> _logger;

        public MatchController(Random random, IMatchService service,IMapper mapper, ILogger<TournamentController> logger)
        {
            _random = random;
            _service = service;
            _mapper = mapper;
            _logger = logger;
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



        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMatchDropdownsValies();
            ViewBag.Participants = new SelectList(movieDropdownsData.Participants, "Id", "Name", "Surname");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewMatchVm match)
        {
            if (!ModelState.IsValid)
            {
                var matchDropDownValues = await _service.GetNewMatchDropdownsValies();

                ViewBag.Participants = new SelectList(matchDropDownValues.Participants, "Id", "Name", "Surname");
                return View(match);
            }

            await _service.AddNewMatchAsync(match);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddRandomMatch()
        {
            return View();
        }

        [HttpPost]
        [Route("Match/AddRandomMatch")]
        public async Task<IActionResult> AddRandomMatchAsync()
        {
            try
            {
                await _service.AddRandomMatchAsync();
                var participants = await _service.GetRandomizedParticipantsList();
                var matchResultViewModel = new MatchResultViewModel
                {
                    Participant1 = participants.Participants[0],
                    Participant2 = participants.Participants[1],
                    Message = "A new match has been created between two random participants."
                };
                return View("MatchResult", matchResultViewModel);
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
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

            var newMatchVms = _mapper.Map<List<NewMatchVm>>(matches);

            return View(newMatchVms);
        }

        public async Task<ActionResult> MakeTournamentLadder()
        {
            await _service.MakeTournamentLadder();
            var matches = await _service.GetAllMatchesAsync();
            var newMatchVms = _mapper.Map<List<NewMatchVm>>(matches);

            return View(newMatchVms);
        }

        public async Task<IActionResult> SelectWinners(int roundNumber)
        {
            var matches = await _service.GetMatchesForSelectionAsync(roundNumber);
            var matchViewModels = _mapper.Map<List<NewMatchVm>>(matches);
            return View(matchViewModels);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNextRound(List<WinnerSelectionVM> winners)
        {
            //if (winners.Count % 2 != 0)
            //{
            //    throw new InvalidOperationException("The number of winners should be even.");
            //}

            //int numberOfMatches = winners.Count / 2;

            //for (int i = 0; i < numberOfMatches; i++)
            //{
            //    var winner1 = winners[i * 2];
            //    var winner2 = winners[i * 2 + 1];

            //    var newMatch = new NewMatchVm()
            //    {
            //        RoundNumber = 2,
            //        WinnerId = 0,
            //        ParticipantsIds = new List<int> { winner1.WinnerId, winner2.WinnerId }
            //    };

            //    await _service.AddNewMatchAsync(newMatch);
            //}

            await _service.CreateNextRound(winners);

            return RedirectToAction("TournamentLadder");
        }


    }
}

