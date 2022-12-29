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

        // GET: HomeController1

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

        [HttpGet]
        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Participant participant)
        //{
        //    try
        //    {
        //        _service.Create(participant);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
