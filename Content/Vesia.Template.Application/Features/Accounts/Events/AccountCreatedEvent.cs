using Vesia.Template.Domain.AccountManagement.Events;
using Vesia.Dispatch.Interfaces;

namespace Vesia.Template.Application.Features.Accounts.Events;

public class AccountCreatedEventHandler() : INotificationHandler<AccountCreatedEvent>
{

    public Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        //Add handling of event!
        
        return Task.CompletedTask;
    }
}