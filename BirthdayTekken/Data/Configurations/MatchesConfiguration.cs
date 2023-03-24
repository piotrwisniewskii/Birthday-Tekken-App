
using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BirthdayTekken.Data.Configurations
{
    //public class MatchesConfiguration : IEntityTypeConfiguration<Match>
    //{
    //    public void Configure(EntityTypeBuilder<Match> builder)
    //    {
    //        builder
    //            .HasKey(x => x.Id);

    //        builder
    //            .HasOne(m => m.Participant)
    //            .WithMany(p => p.Matches)
    //            .HasForeignKey(p => p.ParticipantId)
    //            .OnDelete(DeleteBehavior.Cascade);

    //    }
    //}
}
