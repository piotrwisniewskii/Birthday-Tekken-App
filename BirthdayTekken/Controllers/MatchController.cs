using BirthdayTekken.Data;
using BirthdayTekken.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly AppDbContext _context;

        public MatchController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var participants = _context.Participants.ToList();

            var matches = GenerateTournamentLadder(participants);

            return View(matches);
        }

        private List<Match> GenerateTournamentLadder(List<Participant> participants)
        {
            var matches = new List<Match>();

            var participantCount = participants.Count;

            var rounds = (int)Math.Ceiling(Math.Log(participantCount, 2));

            for (int i = 1; i <= rounds; i++)
            {
                var matchCount = (int)Math.Pow(2, rounds - i);

                for (int j = 1; j <= matchCount; j++)
                {
                    var match = new Match
                    {
                        RoundNumber = i,
                        Participant1Id = participants[(j - 1) * 2].Id,
                        Participant2Id = participants[(j - 1) * 2 + 1].Id
                    };

                    _context.Matches.Add(match);

                    matches.Add(match);
                }
            }

            _context.SaveChanges();

            return matches;
        }
    }
}
