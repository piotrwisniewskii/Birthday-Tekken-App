using BirthdayTekken.Data;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Media;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _service;
        private readonly Random _random;

        public MatchController(Random random, IMatchService service)
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


        public async Task<IActionResult> GenerateMatch()
        {
            var shuffledParticipants = await _service.GetNewMatchDropdownsValies();
            var participants = shuffledParticipants.Participants
                .OrderBy(p => _random.Next()).ToList();

            var roundMatch = new NewMatchVm(participants[0], participants[1]);
            return View(roundMatch);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateMatch(int winnerId, int loserId)
        {
            await _service.RemoveParticipantAsync(loserId);
            return RedirectToAction(nameof(Index));
        }


    }
}

