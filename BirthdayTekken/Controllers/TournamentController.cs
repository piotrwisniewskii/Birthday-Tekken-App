using BirthdayTekken.Data;
using BirthdayTekken.Models.ViewModel;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Rules;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BirthdayTekken.Controllers
{
    public class TournamentController : Controller
    {
        private readonly AppDbContext _context;
        public TournamentController(AppDbContext context)
        {
            _context = context;
        }
        // GET: TournamentController
        public async Task<ActionResult> Index()
        {
            var model = await _context.Tournaments.ToListAsync();
            return View(model);
        }

        // GET: TournamentController/Details/5
        //        public ActionResult Details(int id)
        //        {
        //            var model = _tournamentService.GetAll().First(t=>t.Id == id);
        //            return View(model);
        //        }

        //        // GET: TournamentController/Create
        //        public ActionResult Create()
        //        {
        //            return View(new TournamentViewModel{Participants = _participantsService.GetAllParticipants()});
        //        }

        //        // POST: TournamentController/Create
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create(TournamentViewModel vm)
        //        {
        //            try
        //            {

        //                _tournamentService.Create(vm.TournamentModel);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        //        // GET: TournamentController/Edit/5
        //        public ActionResult Edit(int id)
        //        {
        //            return View();
        //        }

        //        // POST: TournamentController/Edit/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit(int id, IFormCollection collection)
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

        //        // GET: TournamentController/Delete/5
        //        public ActionResult Delete()
        //        {
        //            return View();
        //        }

        //        // POST: TournamentController/Delete/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Delete(int id)
        //        {
        //            try
        //            {
        //                _tournamentService.Delete(id);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }  
    }
}
