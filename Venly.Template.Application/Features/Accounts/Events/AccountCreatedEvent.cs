using Venly.Template.Domain.AccountManagement.Events;
using Venly.Dispatch.Interfaces;

namespace Venly.Template.Application.Features.Accounts.Events;

public class AccountCreatedEventHandler() : INotificationHandler<AccountCreatedEvent>
{

    public Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        //Add handling of event!
        
        return Task.CompletedTask;
    }
}