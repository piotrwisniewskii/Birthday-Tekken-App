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

        public MatchMakerService(AppDbContext context) : base(context) { }

        public async Task AddNewMatchAsync(MatchMaker match)
        {
            var newMatch = new MatchMaker()
            {
                Name = match.Name,
            };
            await _context.Matches.AddAsync(newMatch);

            await _context.SaveChangesAsync();
        }

        public async Task<NewTournamentDropdownsVM> GetParticipantsLIst()
        {
            var response = new NewTournamentDropdownsVM()
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
                .Include(am => am.Participants_Tournaments)
                .ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return MatchDetails;
        }

    }
}
