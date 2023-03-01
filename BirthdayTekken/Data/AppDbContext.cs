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
            modelBuilder.Entity<Participant_Tournament>().HasKey(pt => new
            {
                pt.ParticipantId,
                pt.TournamentId,
            });



            modelBuilder.Entity<Participant_MatchMaker>().HasKey(pm => new
            {
                pm.MatchMakerId
            });

            modelBuilder.Entity<Participant_Tournament>()
                .HasOne(t => t.Tournament)
                .WithMany(pt => pt.Participants_Tournaments)
                .HasForeignKey(t => t.TournamentId);

            modelBuilder.Entity<Participant_Tournament>()
               .HasOne(p => p.Participant)
               .WithMany(pt => pt.Participant_Tournaments)
               .HasForeignKey(p => p.ParticipantId);



            modelBuilder.Entity<Participant_MatchMaker>()
            .HasOne(mm => mm.MatchMaker)
            .WithMany(pm=>pm.Participant_MatchMakers)
            .HasForeignKey(mm => mm.MatchMakerId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Participant_Tournament> Participants_Tournaments { get; set; }
        public DbSet<Participant_MatchMaker> MatchMakers { get; set; }
        public DbSet<MatchMaker> Matches { get; set; }
    }
}
