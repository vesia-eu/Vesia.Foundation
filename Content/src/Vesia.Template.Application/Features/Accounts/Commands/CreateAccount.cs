using Vesia.Template.Domain.AccountManagement.AggragateRoot;
using Vesia.Template.Domain.AccountManagement.ValueObjects;
using Vesia.Dispatch.Interfaces;
using Vesia.Dispatch.Interfaces.Messaging;
using Vesia.Template.Application.Common;
using Vesia.Template.Application.Contracts.Repositories;

namespace Vesia.Template.Application.Features.Accounts.Commands;

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