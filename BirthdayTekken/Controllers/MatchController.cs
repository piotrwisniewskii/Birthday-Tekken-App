using BirthdayTekken.Data;
using BirthdayTekken.Models;
using BirthdayTekken.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Media;

namespace BirthdayTekken.Controllers
{
    public class MatchController : Controller
    {
        private readonly AppDbContext _context;
        private readonly Random _random;
        private readonly IParticipantService _participantService;

        public MatchController(AppDbContext context, Random random, IParticipantService participantService)
        {
            _context = context;
            _random = random;
            _participantService = participantService;
        }

        public IActionResult StartTournament()
        {
            var participants = _context.Participants.ToList();
            Match matchFirstRound = new Match
            {
                RoundNumber = 1,
                Participants = participants,

            };
            _context.Matches.Add(matchFirstRound);
            _context.SaveChanges();

            return View(matchFirstRound);
        }

        public IActionResult NextRound(int roundNumber)
        {
            Match previousRound = _context.Matches.Single(r => r.RoundNumber == roundNumber);
            List<Participant> previousParticipants = previousRound.Participants;
            List<Participant> nextParticipants = new List<Participant>();

            while (previousParticipants.Count > 0)
            {
                int index1 = _random.Next(previousParticipants.Count);
                Participant participant1 = previousParticipants[index1];
                previousParticipants.RemoveAt(index1);

                int index2 = _random.Next(previousParticipants.Count);
                Participant participant2 = previousParticipants[index2];
                previousParticipants.RemoveAt(index2);

                Participant nextParticipant = CreateNextParticipant(participant1, participant2);
                nextParticipants.Add(nextParticipant);
            }

            int nextRoundNumber = roundNumber + 1;
            Match nextRound = new Match { RoundNumber = nextRoundNumber, Participants = nextParticipants };
            _context.Matches.Add(nextRound);
            _context.SaveChanges();

            return View(nextRound);
        }


        private Participant CreateNextParticipant(Participant participant1, Participant participant2)
        {

            Participant nextParticipant = new Participant {  };
            nextParticipant = participant1;
            return nextParticipant;
        }




        //public IActionResult Index()
        //{
        //    var participants = _context.Participants.ToList();
        //    var matches = GenerateTournamentLadder(participants);

        //    return View(matches);
        //}

        //private List<Match> GenerateTournamentLadder(List<Participant> participants)
        //{
        //    var matches = new List<Match>();

        //    var participantCount = participants.Count;

        //    var rounds = (int)Math.Ceiling(Math.Log(participantCount, 2));

        //    for (int i = 1; i <= rounds; i++)
        //    {
        //        var matchCount = (int)Math.Pow(2, rounds - i);

        //        for (int j = 1; j <= matchCount; j++)
        //        {
        //            var match = new Match
        //            {
        //                RoundNumber = i,
        //                Participant1Id = participants[(j - 1) * 2].Id,
        //                Participant2Id = participants[(j - 1) * 2 + 1].Id
        //            };

        //            _context.Matches.Add(match);

        //            matches.Add(match);
        //        }
        //    }

        //    _context.SaveChanges();

        //    return matches;
        //}
    }
}
