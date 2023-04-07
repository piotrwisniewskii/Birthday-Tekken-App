using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
           .HasOne(m => m.Winner)
           .WithMany()
           .HasForeignKey(m => m.WinnerId)
           .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Participant_Tournament> Participants_Tournaments { get; set; }
        public DbSet<Participant_Match> Participants_Matches { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
