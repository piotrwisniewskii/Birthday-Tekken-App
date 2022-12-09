using BirthdayTekken.Models;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayTekken.Controllers
{
    [Route("participants")]
    public class TekkenParticipantsController : Controller
    {
        private IParticipantsService _participantService;
        public TekkenParticipantsController(IParticipantsService participantsService)
        {
            _participantService = participantsService;
        }

        // GET: HomeController1
        [Route("")]
        public ActionResult Index()
        {
            var model = _participantService.GetAllParticipants();
            return View(model);
        }

        // GET: HomeController1/Details/5
        [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        [HttpGet]
        // GET: HomeController1/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]


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
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:int}")]
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
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var model = _participantService.GetById(id);
            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id:int}")]
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

//        public ActionResult Randomize()
//        {
//            var model = _participantService.GetAllParticipants();
//            var random = new Random();
//            var randomized = random.Next(model.Count);
//            return View(randomized);
//        }

//        // POST: TournamentController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Randomize(Tournament tournament)
//        {
//            try
//            {

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
