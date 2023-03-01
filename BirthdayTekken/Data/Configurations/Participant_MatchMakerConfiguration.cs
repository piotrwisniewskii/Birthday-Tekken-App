using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BirthdayTekken.Data.Configurations
{
    public class Participant_MatchMakerConfiguration : IEntityTypeConfiguration<Participant_MatchMaker>
    {
        public void Configure(EntityTypeBuilder<Participant_MatchMaker> builder)
        {
            builder.HasKey(pm => new
            {
                pm.MatchMakerId,
                pm.ParticipantId
            });

            builder
            .HasOne(mm => mm.MatchMaker)
            .WithMany(pm => pm.Participant_MatchMakers)
            .HasForeignKey(mm => mm.MatchMakerId);

            builder
           .HasOne(mm => mm.Participant)
           .WithMany(pm => pm.Participant_MatchMaker)
           .HasForeignKey(mm => mm.ParticipantId);
        }
    }
}
