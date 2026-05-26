using Venly.Template.Domain.AccountManagement.ValueObjects;
using Venly.Template.Domain.Common;

namespace Venly.Template.Domain.AccountManagement.Events;

public record AccountDeactivatedEvent(AccountId AccountId) : DomainEvent;