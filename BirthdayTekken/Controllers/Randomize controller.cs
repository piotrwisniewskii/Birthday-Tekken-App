using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayTekken.Controllers
{
    public class Randomize_controller : Controller
    {
        private readonly IParticipantService _service;

        public Randomize_controller(IParticipantService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Randomize()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }
    }
}
