
using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BirthdayTekken.Data.Configurations
{
    public class MatchesConfiguration : IEntityTypeConfiguration<Participant_Match>
    {
        public void Configure(EntityTypeBuilder<Participant_Match> builder)
        {
            builder
                .HasKey(x => new {x.MatchId, x.ParticipantId });

            builder
                .HasOne(t => t.Participant)
                .WithMany(pt => pt.Participant_Matches)
                .HasForeignKey(t => t.ParticipantId);

            builder
               .HasOne(p => p.Match)
               .WithMany(pt => pt.Participant_Matches)
               .HasForeignKey(p => p.MatchId);
        }
    }
}
