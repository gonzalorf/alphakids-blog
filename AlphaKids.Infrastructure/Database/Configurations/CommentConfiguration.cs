using AlphaKids.Domain.Comments;
using AlphaKids.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaKids.Infrastructure.Database.Configurations;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new CommentId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.AuthorId);
    }
}
