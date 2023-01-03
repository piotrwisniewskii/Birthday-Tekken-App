using BirthdayTekken.Models;
using BirthdayTekken.Repository;
using BirthdayTekken.Services;
using System.Collections.ObjectModel;
using BirthdayTekken.Enums;
using BirthdayTekken.Data;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Services
{
    public class ParticipantService : IParticipantService
    {

        private readonly AppDbContext _context;

        public ParticipantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Participant>> GetAllAsync()
        {
            var result = await _context.Participants.ToListAsync();
            return result;
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            var result = await _context.Participants.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public void Update(int id, Participant model)
        {
            throw new NotImplementedException();
        }
    }


}
