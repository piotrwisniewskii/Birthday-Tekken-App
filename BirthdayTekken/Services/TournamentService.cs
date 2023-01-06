using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BirthdayTekken.Services
{
    public class TournamentService : EntityBaseRepository<Tournament>,ITournamentService
    {
        private readonly AppDbContext _context;
        public TournamentService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tournament> GetTournamentByIdAsync(int id)
        {
            var tournamentDetails = await _context.Tournaments     
                .Include(am => am.Participants_Tournaments).ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return tournamentDetails;
        }
    }
}
