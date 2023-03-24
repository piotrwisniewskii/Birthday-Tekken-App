
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
                .HasMany(m => m.Participants)
                .WithMany(p => p.Matches);
        }
    }
}
