using Vesia.Template.Application.Common;
using Vesia.Template.Domain.Abstractions;
using Vesia.Dispatch.Interfaces;

namespace Vesia.Template.Infrastructure.Persistence;

internal class UnitOfWork(ApplicationDbContext context, IDispatcher dispatcher) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Step 1: Collect all domain events from tracked entities
        var entitiesWithEvents = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count != 0)
            .ToList();

        var domainEvents = entitiesWithEvents
            .SelectMany(e => e.DomainEvents)
            .ToList();

        // Step 2: Save to database first
        var result = await context.SaveChangesAsync(cancellationToken);

        // Step 3: Publish all events AFTER successful save
        foreach (var domainEvent in domainEvents)
        {
            await dispatcher.PublishAsync((dynamic)domainEvent, cancellationToken);
        }

        // Step 4: Clear events from aggregates
        foreach (var entity in entitiesWithEvents)
        {
            entity.ClearDomainEvents();
        }

        return result;
    }
}