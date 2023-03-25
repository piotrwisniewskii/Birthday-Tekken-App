using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Services
{
    public class MatchService : EntityBaseRepository<Match>, IMatchService
    {
        private readonly AppDbContext _context;

        public MatchService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMatchAsync(NewMatchVm data)
        {
            var newMatch = new Match()
            {
                RoundNumber = data.RoundNumber,
                WinnerId = data.WinnerId,
            };
            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();

            foreach (var participantId in data.ParticipantsIds)
            {
                var newParticipantMatch = new Participant_Match()
                {
                    MatchId = newMatch.Id,
                    ParticipantId = participantId
                };
                await _context.Participants_Matches
                    .AddAsync(newParticipantMatch);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            var matchDetails = await _context.Matches
                .Include(am => am.Participant_Matches)
                .ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return matchDetails;
        }

        public async Task<NewMatchDropdownsVM> GetNewMatchDropdownsValies()
        {
            var response = new NewMatchDropdownsVM()
            {
                Participants = await _context.Participants
                .OrderBy(n => n.Name)
                .ToListAsync()
            };

            return response;
        }

    }
}
