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

        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        //// GET: HomeController1/Details/5
        //[Route("details/{id:int}")]
        //public ActionResult Details(int id)
        //{
        //    var model = _participantService.GetById(id);
        //    return View(model);
        //}

        // GET: HomeController1/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: HomeController1/Create

       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ProfilePictureURL", "Name", "Surname","Champion")]Participant participant)
        {
            if (!ModelState.IsValid)
            {
            return View(participant);
            }

            _service.Add(participant);
            return RedirectToAction(nameof(Index));
        }

        //// GET: HomeController1/Edit/5
        //[Route("edit/{id:int}")]
        //public ActionResult Edit(int id)
        //{
        //    var model = _participantService.GetById(id);
        //    return View(model);
        //}

        //// POST: HomeController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("edit/{id:int}")]
        //public ActionResult Edit(Participant participant)
        //{
        //    try
        //    {
        //        _participantService.Update(participant);
        //        return RedirectToAction(nameof(Details), participant);
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController1/Delete/5
        //[Route("delete/{id:int}")]
        //public ActionResult Delete(int id)
        //{
        //    var model = _participantService.GetById(id);
        //    return View(model);
        //}

        //// POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("delete/{id:int}")]
        //public ActionResult Delete(Participant model)
        //{
        //    try
        //    {
        //        _participantService.Delete(model.Id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
