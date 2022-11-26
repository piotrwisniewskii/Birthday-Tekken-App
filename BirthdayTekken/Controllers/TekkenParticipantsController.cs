using BirthdayTekken.Models;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayTekken.Controllers
{
    public class TekkenParticipantsController : Controller
    {
        private IParticipantsService _participantService;
        public TekkenParticipantsController(IParticipantsService participantsService)
        {
            _participantService = participantsService;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            var model = _participantService.GetAllParticipants();
            return View(model);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participants participant)
        {
            try
            {
                _participantService.Create(participant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Participants participant)
        {
            try
            {
                _participantService.Update(participant);
                return RedirectToAction(nameof(Details), participant);
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Participants model)
        {
            try
            {
                _participantService.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
