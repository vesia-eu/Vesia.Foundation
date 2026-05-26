using Application.Features.Accounts.DTOs;

namespace Application.Contracts.Queries;

public interface IAccountQueries
{
    Task<IReadOnlyList<AccountDTO>> GetAllAccountsQuery(CancellationToken cancellationToken);
    Task<AccountDTO?> GetAccountByUid(Guid uid, CancellationToken cancellationToken);
}