using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirthdayTekken.Controllers
{
    public class MatchMakerController : Controller
    {
        private readonly IMatchMakerService _service;

        public MatchMakerController(IMatchMakerService service)
        {
            _service= service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> ChooseMatch()
        {
            var matchDropDownData = await _service.GetParticipantsLIst();
            ViewBag.Participants = new SelectList(matchDropDownData.Participants, "Id", "Name", "Surname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChooseMatch(NewMatchMakerVM match)
        {
            if (!ModelState.IsValid)
            {
                var matchDropDownData = await _service.GetParticipantsLIst();

                ViewBag.Participants = new SelectList(matchDropDownData.Participants, "Id", "Name", "Surname");
                return View(match);
            }

            await _service.AddNewMatchAsync(match);
            return RedirectToAction(nameof(Index));
        }
    }
}
