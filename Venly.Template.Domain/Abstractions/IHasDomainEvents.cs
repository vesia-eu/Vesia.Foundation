using Venly.Template.Domain.Common;

namespace Venly.Template.Domain.Abstractions;

public interface IHasDomainEvents
{
    IReadOnlyCollection<DomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}