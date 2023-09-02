using NanoBlogEngine.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NanoBlogEngine.Infrastructure.Database.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable("Users", SchemaNames.Blog);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
                    .HasConversion(id => id.Value, value => new UserId(value));

        _ = builder.Property(e => e.Role)
                    .HasConversion(r => r.Name, value => UserRole.CreateFromName(value));
    }
}
