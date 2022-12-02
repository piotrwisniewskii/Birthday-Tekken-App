using BirthdayTekken.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Rules;
using System.Runtime.CompilerServices;

namespace BirthdayTekken.Controllers
{
    public class TournamentController : Controller
    {
        private ITournamentRepository _tournamentRepository;
        public TournamentController(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
        // GET: TournamentController
        public ActionResult Index()
        {
            var model = _tournamentRepository.GetAll();
            return View(model);
        }

        // GET: TournamentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TournamentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TournamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
