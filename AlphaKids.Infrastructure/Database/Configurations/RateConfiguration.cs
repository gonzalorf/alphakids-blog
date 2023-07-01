using AlphaKids.Domain.Rates;
using AlphaKids.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaKids.Infrastructure.Database.Configurations;

internal class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("Rates");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new RateId(value));

        builder.HasOne(c => c.Rater)
            .WithMany()
            .HasForeignKey("RaterId");
    }
}
