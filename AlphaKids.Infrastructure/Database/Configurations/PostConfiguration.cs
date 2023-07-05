using AlphaKids.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaKids.Infrastructure.Database.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        _ = builder.ToTable("Posts");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id).HasConversion(
            id => id.Value
            , value => new PostId(value));

        _ = builder.HasMany(o => o.Comments)
            .WithOne()
            .HasForeignKey("PostId")
            .IsRequired();

        _ = builder.HasMany(o => o.Rates)
            .WithOne()
            .HasForeignKey("PostId")
            .IsRequired();

        _ = builder
            .HasMany(o => o.Categories)
            .WithMany();

    }
}
