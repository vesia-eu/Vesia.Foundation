using Vesia.Template.Domain.AccountManagement.ValueObjects;
using Vesia.Template.Domain.Common;

namespace Vesia.Template.Domain.AccountManagement.Events;

public record AccountDeactivatedEvent(AccountId AccountId) : DomainEvent;