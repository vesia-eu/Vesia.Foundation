using Venly.Template.Domain.Abstractions;

namespace Venly.Template.Domain.Common;

public abstract record DomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}