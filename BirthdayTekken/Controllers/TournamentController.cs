using BirthdayTekken.Data;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }
    }
}
