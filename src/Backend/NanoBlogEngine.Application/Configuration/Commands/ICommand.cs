using System;
using System.Dynamic;
using MediatR;

namespace NanoBlogEngine.Application.Configuration.Commands;

public interface ICommand
{
    Guid Id { get; }
}

//public interface ICommand<out TResult> : ICommand
//{

//}