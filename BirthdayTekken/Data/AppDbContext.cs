using BirthdayTekken.Models;
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
            modelBuilder.Entity<Participant_Tournament>().HasKey(pt => new
            {
                pt.ParticipantId,
                pt.TournamentId
            });

            modelBuilder.Entity<Participant_Tournament>()
                .HasOne(t => t.Tournament)
                .WithMany(pt => pt.Participant_Tournaments)
                .HasForeignKey(t => t.TournamentId);

            modelBuilder.Entity<Participant_Tournament>()
               .HasOne(p => p.Participant)
               .WithMany(pt => pt.Participant_Tournaments)
               .HasForeignKey(p => p.ParticipantId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Participant_Tournament> Participant_Tournaments { get; set; }
    }
}
