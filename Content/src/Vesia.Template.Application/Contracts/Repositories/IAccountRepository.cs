using Vesia.Template.Domain.AccountManagement.AggragateRoot;

namespace Vesia.Template.Application.Contracts.Repositories;

public interface IAccountRepository
{
    // write operations + existence/uniqueness checks needed for commands
    Task<bool> AccountExistsAsync(string accountName, CancellationToken cancellationToken);
    void Add(Account account);
}