using MediatR;

namespace NanoBlogEngine.Application.Configuration.Commands;

public abstract record CommandBase : ICommand, IRequest
{
    public Guid Id { get; }

    protected CommandBase()
    {
        Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        Id = id;
    }
}

public abstract record CommandBase<TResult> : ICommand, IRequest<TResult>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        Id = id;
    }
}