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

        //    public IActionResult StartTournament()
        //    {
        //        var participants = _context.Participants.ToList();

        //        var guidNumber = Guid.NewGuid();

        //        Match matchFirstRound = new Match
        //        {

        //            RoundNumber = guidNumber,
        //            Participants = participants,

        //        };

        //        _context.Matches.Add(matchFirstRound);


        //        return View(matchFirstRound);
        //    }

        //    public IActionResult NextRound(Guid roundNumber)
        //    {
        //        Match previousRound = _context.Matches.SingleOrDefault(p => p.RoundNumber == roundNumber);
        //        if (previousRound == null)
        //        {
        //            return NotFound($"No match found with round number {roundNumber}.");
        //        }
        //        List<Participant> previousParticipants = previousRound.Participants;
        //        List<Participant> nextParticipants = new List<Participant>();

        //        while (previousParticipants.Count > 0)
        //        {
        //            int index1 = _random.Next(previousParticipants.Count);
        //            Participant participant1 = previousParticipants[index1];
        //            previousParticipants.RemoveAt(index1);

        //            int index2 = _random.Next(previousParticipants.Count);
        //            Participant participant2 = previousParticipants[index2];
        //            previousParticipants.RemoveAt(index2);

        //            Participant nextParticipant = CreateNextParticipant(participant1, participant2);
        //            nextParticipants.Add(nextParticipant);
        //        }

        //        int nextRoundNumber = 1 + 1;
        //        Match nextRound = new Match { Id = nextRoundNumber, Participants = nextParticipants };
        //        _context.Matches.Add(nextRound);
        //        _context.SaveChanges();

        //        return View(nextRound);
        //    }


        //    private Participant CreateNextParticipant(Participant participant1, Participant participant2)
        //    {

        //        Participant nextParticipant = new Participant {  };
        //        nextParticipant = participant1;
        //        return nextParticipant;
        //    }

        //}
    }
}

