using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Data.Base
{
    public class MatchRepository : EntityBaseRepository<Match>,IMatchRepository
    {
        private readonly AppDbContext _context;
        public MatchRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMatchAsync(NewMatchVm newMatchVm)
        {
            var newMatch = new Match
            {
                RoundNumber = newMatchVm.RoundNumber,
                WinnerId = newMatchVm.WinnerId,
                TournamentId = newMatchVm.TournamentId,
            };

            await AddAsync(newMatch);

            var participantIds = newMatchVm.ParticipantsIds.Distinct().ToList();

            var participants = await _context.Participants.Where(p => participantIds.Contains(p.Id)).ToListAsync();

            var participantMatches = participants.Select(participant => new Participant_Match
            {
                MatchId = newMatch.Id,
                ParticipantId = participant.Id
            }).ToList();

            foreach (var participantMatch in participantMatches)
            {
                await _context.Participants_Matches.AddAsync(participantMatch);
            }

            await _context.SaveChangesAsync();
        }


    }
}
