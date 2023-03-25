using BirthdayTekken.Data;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Media;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        private readonly Random _random;

        public MatchController( Random random, IMatchService service)
        {
            _random = random;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync(n => n.Participant_Matches);
            return View(model);
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


        //    public IActionResult StartTournament()
        //    {
        //        // Get all matches from the database and group them by round number
        //        var matches = db.Participant_Matches.Include(m => m.Match).Include(m => m.Participant)
        //                        .OrderBy(m => m.Match.RoundNumber).ToList();
        //        var rounds = matches.GroupBy(m => m.Match.RoundNumber);

        //        // Create a list of lists to hold the matches for each round
        //        var roundsList = new List<List<Participant_Match>>();

        //        foreach (var round in rounds)
        //        {
        //            // Create a list to hold the matches for this round
        //            var roundMatches = new List<Participant_Match>();

        //            foreach (var match in round)
        //            {
        //                roundMatches.Add(match);
        //            }

        //            // Add the matches for this round to the list of rounds
        //            roundsList.Add(roundMatches);
        //        }

        //        // Create a new TournamentLadderViewModel and pass it to the view
        //        var model = new TournamentLadderViewModel { Rounds = roundsList };
        //        return View(model);
        //    }

        //    // Pass the list of rounds to the view
        //    return View(rounds);
        //}

        //    public IActionResult NextRound(Guid roundNumber)
        //    {
        //        Match previousRound = _context.Matches.SingleOrDefault(p => p.RoundNumber == roundNumber);
        //        if (previousRound == null)
        //        {
        //            return NotFound($"No match found with round number {roundNumber}.");
        //        }
        //        List<Participant> previousParticipants = previousRound.Participants;
        //        List<Participant> nextParticipants = new List<Participant>();

        //        while (previousParticipants.Count > 0)
        //        {
        //            int index1 = _random.Next(previousParticipants.Count);
        //            Participant participant1 = previousParticipants[index1];
        //            previousParticipants.RemoveAt(index1);

        //            int index2 = _random.Next(previousParticipants.Count);
        //            Participant participant2 = previousParticipants[index2];
        //            previousParticipants.RemoveAt(index2);

        //            Participant nextParticipant = CreateNextParticipant(participant1, participant2);
        //            nextParticipants.Add(nextParticipant);
        //        }

        //        int nextRoundNumber = 1 + 1;
        //        Match nextRound = new Match { Id = nextRoundNumber, Participants = nextParticipants };
        //        _context.Matches.Add(nextRound);
        //        _context.SaveChanges();

        //        return View(nextRound);
        //    }


        //    private Participant CreateNextParticipant(Participant participant1, Participant participant2)
        //    {

        //        Participant nextParticipant = new Participant {  };
        //        nextParticipant = participant1;
        //        return nextParticipant;
        //    }

        //}
    }
}

