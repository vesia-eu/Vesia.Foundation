using Vesia.Template.Application.Contracts.Repositories;
using Vesia.Template.Domain.AccountManagement.AggragateRoot;
using Microsoft.EntityFrameworkCore;
using Vesia.Template.Infrastructure.Persistence;

namespace Vesia.Template.Infrastructure.Accounts;

internal class AccountRepository(ApplicationDbContext context) : IAccountRepository
{
    public async Task<bool> AccountExistsAsync(string accountName, CancellationToken cancellationToken)
    {
        return await context.Accounts.AnyAsync(a => a.AccountName == accountName, cancellationToken);
    }

    //Domain Account Aggregate is added to the DB - No need to validate since the Domain layer has already done this
    public void Add(Account account)
    {
        context.Accounts.Add(account);
    }
}