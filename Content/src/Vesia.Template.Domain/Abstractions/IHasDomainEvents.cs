using Vesia.Template.Domain.Common;

namespace Vesia.Template.Domain.Abstractions;

public interface IHasDomainEvents
{
    IReadOnlyCollection<DomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}