using Venly.Template.Domain.AccountManagement.ValueObjects;
using Venly.Template.Domain.Common;

namespace Venly.Template.Domain.AccountManagement.Events;

public record AccountUpdatedEvent(AccountId AccountId) : DomainEvent;