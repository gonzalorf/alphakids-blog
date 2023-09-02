using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NanoBlogEngine.Application.Outbox;

namespace NanoBlogEngine.Infrastructure.Database.Configurations;

internal class OutboxConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        _ = builder.ToTable("OutboxMessages", SchemaNames.Blog);

        _ = builder.HasKey(b => b.Id);
    }
}
