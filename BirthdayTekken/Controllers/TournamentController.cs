using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Repository;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Rules;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BirthdayTekken.Controllers
{
    public class TournamentController : Controller
    {
        private ITournamentService _tournamentService;
        private IParticipantsService _participantsService;
        public TournamentController(ITournamentService tournamentRepository, IParticipantsService participantsService)
        {
            _tournamentService = tournamentRepository;
            _participantsService = participantsService;
        }
        // GET: TournamentController
        public ActionResult Index()
        {
            var model = _tournamentService.GetAll();
            return View(model);
        }

        // GET: TournamentController/Details/5
        public ActionResult Details(int id)
        {
            var model = _tournamentService.GetAll().First(t=>t.Id == id);
            return View(model);
        }

        // GET: TournamentController/Create
        public ActionResult Create()
        {
            return View(new TournamentViewModel{Participants = _participantsService.GetAllParticipants()});
        }

        // POST: TournamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TournamentViewModel vm)
        {
            try
            {
                
                _tournamentService.Create(vm.TournamentModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TournamentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TournamentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TournamentController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: TournamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _tournamentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }  
    }
}
