using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using System.Reflection;

namespace BirthdayTekken.Services
{
    public class TournamentService : EntityBaseRepository<Tournament>,ITournamentService
    {
        public TournamentService(AppDbContext context) : base(context)
        {
        }
    }
}
