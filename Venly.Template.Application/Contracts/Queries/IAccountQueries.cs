using Venly.Template.Application.Features.Accounts.DTOs;

namespace Venly.Template.Application.Contracts.Queries;

public interface IAccountQueries
{
    Task<IReadOnlyList<AccountDTO>> GetAllAccountsQuery(CancellationToken cancellationToken);
    Task<AccountDTO?> GetAccountByUid(Guid uid, CancellationToken cancellationToken);
}