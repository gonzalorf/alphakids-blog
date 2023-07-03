using MediatR;

namespace AlphaKids.Domain.SeedWork;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}