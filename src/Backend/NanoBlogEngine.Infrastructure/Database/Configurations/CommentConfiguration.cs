using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Infrastructure.Database.Configurations;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        _ = builder.ToTable("Comments", SchemaNames.Blog);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new CommentId(value));
        
        _ = builder.Property(e => e.PostId)
            .HasConversion(id => id.Value, value => new PostId(value));

        _ = builder.Property(e => e.AuthorId)
            .HasConversion(id => id.Value, value => new UserId(value));
    }
}
