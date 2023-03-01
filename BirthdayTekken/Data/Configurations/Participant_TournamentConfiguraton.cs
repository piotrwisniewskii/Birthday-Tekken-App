using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BirthdayTekken.Data.Configurations
{
    public class Participant_TournamentConfiguraton : IEntityTypeConfiguration<Participant_Tournament>
    {
        public void Configure(EntityTypeBuilder<Participant_Tournament> builder)
        {
            builder.HasKey(pt => new
            {
                pt.ParticipantId,
                pt.TournamentId,
            });

            builder
                .HasOne(t => t.Tournament)
                .WithMany(pt => pt.Participants_Tournaments)
                .HasForeignKey(t => t.TournamentId);

            builder
               .HasOne(p => p.Participant)
               .WithMany(pt => pt.Participant_Tournaments)
               .HasForeignKey(p => p.ParticipantId);
        }
    }
}
