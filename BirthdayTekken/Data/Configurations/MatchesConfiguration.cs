using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class MatchesConfiguration : IEntityTypeConfiguration<Participant_Match>
{
    public void Configure(EntityTypeBuilder<Participant_Match> builder)
    {
        builder.HasKey(x => new
        {
            x.ParticipantId,
            x.MatchId
        });

        builder
            .HasOne(p => p.Match)
            .WithMany(pt => pt.Participant_Matches)
            .HasForeignKey(p => p.MatchId);

        builder
            .HasOne(t => t.Participant)
            .WithMany(pm => pm.Participant_Matches)
            .HasForeignKey(t => t.ParticipantId);
    }
}
