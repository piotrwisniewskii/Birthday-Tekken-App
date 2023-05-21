using BirthdayTekken.Models;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayTekken.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipantService _service;
        public ParticipantsController(IParticipantService service)
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
        public async Task<IActionResult> Create(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return View(participant);
            }

            if (participant.ProfilePictureFile != null)
            {
                using var memoryStream = new MemoryStream();
                await participant.ProfilePictureFile.CopyToAsync(memoryStream);
                participant.ProfilePicture = memoryStream.ToArray();
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
        public async Task<IActionResult> Edit(int id, Participant participant)
        {
            if(!ModelState.IsValid)
            {
                return View(participant);
            }

            if (participant.ProfilePictureFile != null)
            {
                using var memoryStream = new MemoryStream();
                await participant.ProfilePictureFile.CopyToAsync(memoryStream);
                participant.ProfilePicture = memoryStream.ToArray();
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



        public FileContentResult GetImage(int id)
        {
            var participant = _service.GetByIdAsync(id).Result;
            if (participant != null)
            {
                return File(participant.ProfilePicture, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

    }
}
