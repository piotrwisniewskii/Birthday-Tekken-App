using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BirthdayTekken.Services
{
    public class TournamentService : EntityBaseRepository<Tournament>, ITournamentService
    {
        private readonly AppDbContext _context;
        public TournamentService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewTournamentAsync(NewTournamentVM data)
        {
            var newTournament = new Tournament()
            {
                Name = data.Name,
                TournamentDate = data.TournamentDate,
                WinnerId = data.WinnerId,
                PlayersNumber = data.PlayersNumber,
            };
            await _context.Tournaments.AddAsync(newTournament);
            await _context.SaveChangesAsync();

            foreach (var participantId in data.ParticipantsIds)
            {
                var newParticipantTournament = new Participant_Tournament()
                {
                    TournamentId = newTournament.Id,
                    ParticipantId = participantId
                };
            await _context.Participants_Tournaments.AddAsync(newParticipantTournament);
            }
            await _context.SaveChangesAsync();


        }
        public async Task<NewTournamentDropdownsVM> GetNewTournamentDropdownsValies()
        {
            var response = new NewTournamentDropdownsVM()
            {
                Participants = await _context.Participants.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
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

