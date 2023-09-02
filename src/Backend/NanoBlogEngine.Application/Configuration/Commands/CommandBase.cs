using System;

namespace NanoBlogEngine.Application.Configuration.Commands;

public abstract record CommandBase : ICommand
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

public abstract record CommandBase<TResult> : CommandBase, ICommand<TResult>
{
    protected CommandBase() : base()
    {
    }

    protected CommandBase(Guid id) : base(id)
    {
    }
}