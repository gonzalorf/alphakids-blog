using MediatR;

namespace NanoBlogEngine.Domain.SeedWork;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}