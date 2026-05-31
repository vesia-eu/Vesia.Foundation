using Vesia.Template.Domain.Abstractions;

namespace Vesia.Template.Domain.Common;

public abstract record DomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}