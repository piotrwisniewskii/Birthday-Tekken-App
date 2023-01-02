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

        public void Add(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
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

        public Participant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Participant model)
        {
            throw new NotImplementedException();
        }
    }


}
