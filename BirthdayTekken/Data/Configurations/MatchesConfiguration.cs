
using BirthdayTekken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BirthdayTekken.Data.Configurations
{
    public class MatchesConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(m => m.Participant1)
                .WithMany(p => p.Matches)
                .HasForeignKey(p => p.Participant1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Participant2)
                .WithMany(p => p.Matches)
                .HasForeignKey(p => p.Participant2Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(p => p.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
