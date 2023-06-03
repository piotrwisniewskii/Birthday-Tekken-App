using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

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

            var participantMatches = newMatchVm.ParticipantsIds.Select(participantId => new Participant_Match
            {
                MatchId = newMatch.Id,
                ParticipantId = participantId
            }).ToList();

            foreach (var participantMatch in participantMatches)
            {
                await _context.Participants_Matches.AddAsync(participantMatch);
            }

            await _context.SaveChangesAsync();
        }
    }
}
