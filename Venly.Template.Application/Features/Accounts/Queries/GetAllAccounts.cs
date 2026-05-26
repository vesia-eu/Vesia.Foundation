using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;
using Venly.Template.Application.Common;
using Venly.Template.Application.Contracts.Queries;
using Venly.Template.Application.Features.Accounts.DTOs;

namespace Venly.Template.Application.Features.Accounts.Queries;

public record GetAllAccountsQuery() : IQuery<Result<IReadOnlyList<AccountDTO>>>;

public class GetUsersRequiringSyncHandler(IAccountQueries accountQueries)
    : IQueryHandler<GetAllAccountsQuery, Result<IReadOnlyList<AccountDTO>>>
{
    public async Task<Result<IReadOnlyList<AccountDTO>>> Handle(GetAllAccountsQuery query, CancellationToken cancellationToken)
    {
        var users = await accountQueries.GetAllAccountsQuery(cancellationToken);
        return Result<IReadOnlyList<AccountDTO>>.Success(users);
    }
}