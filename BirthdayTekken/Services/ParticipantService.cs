using BirthdayTekken.Models;
using BirthdayTekken.Services;
using System.Collections.ObjectModel;
using BirthdayTekken.Enums;
using BirthdayTekken.Data;
using Microsoft.EntityFrameworkCore;
using BirthdayTekken.Data.Base;

namespace BirthdayTekken.Services
{
    public class ParticipantService : EntityBaseRepository<Participant>, IParticipantService
    {

        private readonly AppDbContext _context;

        public ParticipantService(AppDbContext context) : base(context) { }

    }
}
