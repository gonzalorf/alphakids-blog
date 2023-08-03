using NanoBlogEngine.Domain.SeedWork;
using MediatR;

namespace NanoBlogEngine.Application.Behaviors;
public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{

    readonly IUnitOfWork unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if(!typeof(TRequest).Name.EndsWith("Command"))
        {
            return await next();
        }

        var response = await next();

        await unitOfWork.CommitAsync(cancellationToken);

        return response;
    }
}
