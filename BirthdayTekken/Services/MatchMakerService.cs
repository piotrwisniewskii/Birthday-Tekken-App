using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BirthdayTekken.Services
{
    public class MatchMakerService : EntityBaseRepository<MatchMaker>, IMatchMakerService
    {
        private readonly AppDbContext _context;

        public MatchMakerService(AppDbContext context) : base(context) 
        {
            _context= context;
        }

        public async Task AddNewMatchAsync(NewMatchMakerVM match)
        {
            var newMatch = new MatchMaker()
            {
                Name = match.Name,
            };
            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();

            foreach (var participantId in match.ParticipantsIds)
            {
                var participant_MatchMaker = new Participant_MatchMaker()
                {
                    MatchMakerId = newMatch.Id,
                    ParticipantId = participantId
                };
                await _context.MatchMakers.AddAsync(participant_MatchMaker);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewMatchMakerDropdownsVM> GetParticipantsLIst()
        {
            var response = new NewMatchMakerDropdownsVM()
            {
                Participants = await _context.Participants
                .OrderBy(n => n.Name)
                .ToListAsync()
            };
            return response;
        }

        public async Task<MatchMaker> GetMatchById(int id)
        {
            var MatchDetails = await _context.Matches
                .Include(am => am.Participant_MatchMakers)
                .ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);
            return MatchDetails;
        }

    }
}
