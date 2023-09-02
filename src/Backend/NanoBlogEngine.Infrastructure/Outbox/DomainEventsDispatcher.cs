using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using MediatR;
using NanoBlogEngine.Application.Common.Services;
using NanoBlogEngine.Application.Outbox;
using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Infrastructure.Database;
using Newtonsoft.Json;
using SampleProject.Application.Configuration.DomainEvents;
using SampleProject.Domain.SeedWork;
using SampleProject.Infrastructure.Database;
using SampleProject.Infrastructure.Processing.Outbox;

namespace NanoBlogEngine.Infrastructure.Outbox;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly ApplicationDbContext context;

    public DomainEventsDispatcher(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEntities = this.context.ChangeTracker
            .Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Any()).ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents!)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            var type = domainEvent.GetType().FullName;            
            var data =  JsonSerializer.Serialize(domainEvent);


            var outboxMessage = new OutboxMessage(
                domainEvent.OccurredOn,
                type,
                data);
            await context.OutboxMessages.AddAsync(outboxMessage);
        }

    }
}