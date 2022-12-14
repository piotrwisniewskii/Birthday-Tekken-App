using BirthdayTekken.Data;
using BirthdayTekken.Models;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Controllers
{
    public class TekkenParticipantsController : Controller
    {
        private readonly IParticipantService _service;
        public TekkenParticipantsController(IParticipantService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var participantDetails = await _service.GetByIdAsync(id);
            if(participantDetails == null) return View("NotFound");
            return View(participantDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

    

       [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "Name", "Surname","Champion")]Participant participant)
        {
            if (!ModelState.IsValid)
            {
            return View(participant);
            }

            await _service.AddAsync(participant);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var participantDetails = await _service.GetByIdAsync(id);
            if (participantDetails == null) return View("NotFound");
            return View(participantDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL", "Name", "Surname", "Champion", "TournamentsWon")] Participant participant)
        {
            if(!ModelState.IsValid)
            {
                return View(participant);
            }
            await _service.UpdateAsync(id,participant);
            return RedirectToAction(nameof(Index));
        }


        public async Task <IActionResult> Delete(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return View("NotFound");
            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
