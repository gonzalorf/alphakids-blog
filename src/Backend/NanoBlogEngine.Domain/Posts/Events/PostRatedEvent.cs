using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts.Events;

public record PostRatedEvent(PostId PostId) : DomainEventBase;
