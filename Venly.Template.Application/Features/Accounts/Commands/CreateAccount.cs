using Venly.Template.Domain.AccountManagement.AggragateRoot;
using Venly.Template.Domain.AccountManagement.ValueObjects;
using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;
using Venly.Template.Application.Common;
using Venly.Template.Application.Contracts.Repositories;

namespace Venly.Template.Application.Features.Accounts.Commands;

public record CreateAccountCommand(string Username, string Email, string FirstName, string LastName) : ICommand<Result<Guid>>;

public class CreateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateAccountCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var accountId = AccountId.Create();
        var account = Account.Create(accountId, command.Username, command.Email, command.FirstName, command.LastName);
        
        accountRepository.Add(account);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(accountId);
    }
}