using NanoBlogEngine.Domain.SeedWork;
using MediatR;
using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Infrastructure.Outbox;

namespace NanoBlogEngine.Infrastructure.Database.Behaviors;
public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{

    readonly IUnitOfWork unitOfWork;
    readonly IDomainEventsDispatcher domainEventsDispatcher;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork, IDomainEventsDispatcher domainEventsDispatcher)
    {
        this.unitOfWork = unitOfWork;
        this.domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {

        if(!typeof(ICommand).IsAssignableFrom(typeof(TRequest)))
        {
            return await next();
        }

        var response = await next();

        await domainEventsDispatcher.DispatchEventsAsync();

        await unitOfWork.CommitAsync(cancellationToken);

        return response;
    }
}
