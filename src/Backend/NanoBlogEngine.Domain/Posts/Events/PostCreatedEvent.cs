using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts.Events;

public record PostCreatedEvent(PostId PostId) : DomainEventBase;
