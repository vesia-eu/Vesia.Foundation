using Vesia.Dispatch.Interfaces;
using Vesia.Dispatch.Interfaces.Messaging;
using Vesia.Template.Application.Common;
using Vesia.Template.Application.Contracts.Queries;
using Vesia.Template.Application.Features.Accounts.DTOs;

namespace Vesia.Template.Application.Features.Accounts.Queries;

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