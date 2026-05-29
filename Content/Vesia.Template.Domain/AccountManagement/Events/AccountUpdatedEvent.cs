using Vesia.Template.Domain.AccountManagement.ValueObjects;
using Vesia.Template.Domain.Common;

namespace Vesia.Template.Domain.AccountManagement.Events;

public record AccountUpdatedEvent(AccountId AccountId) : DomainEvent;