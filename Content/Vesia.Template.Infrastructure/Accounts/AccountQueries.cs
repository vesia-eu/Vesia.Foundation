using Vesia.Template.Application.Contracts.Queries;
using Vesia.Template.Application.Features.Accounts.DTOs;
using Microsoft.EntityFrameworkCore;
using Vesia.Template.Infrastructure.Persistence;

namespace Vesia.Template.Infrastructure.Accounts;

internal class AccountQueries(IDbContextFactory<ApplicationDbContext> contextFactory) : IAccountQueries
{
    public async Task<IReadOnlyList<AccountDTO>> GetAllAccountsQuery(CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        return await context.Accounts
            .AsNoTracking()
            .Select(a => new AccountDTO(
                a.Id,
                a.AccountName,
                a.Email,
                a.FirstName,
                a.LastName,
                a.ValidTo))
            .ToListAsync(cancellationToken);
    }

    public async Task<AccountDTO?> GetAccountByUid(Guid uid, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        return await context.Accounts
            .AsNoTracking()
            .Where(a => a.Id == uid)
            .Select(a => new AccountDTO(
                a.Id.Value,
                a.AccountName,
                a.Email,
                a.FirstName,
                a.LastName,
                a.ValidTo))
            .FirstOrDefaultAsync(cancellationToken);
    }
}