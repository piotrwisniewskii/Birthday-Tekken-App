using BirthdayTekken.Data;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Rules;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            var tournamentDetails = await _service.GetNewTournamentDropdownsValies();
            if(tournamentDetails != null) return View("NotFound");

            var response = new NewTournamentVM()
            {
                Id
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTournamentVM tournament)
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
    }
}
