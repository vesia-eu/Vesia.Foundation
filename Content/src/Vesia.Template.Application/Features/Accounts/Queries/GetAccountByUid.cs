using Vesia.Dispatch.Interfaces;
using Vesia.Dispatch.Interfaces.Messaging;
using Vesia.Result;
using Vesia.Template.Application.Contracts.Queries;
using Vesia.Template.Application.Features.Accounts.DTOs;

namespace Vesia.Template.Application.Features.Accounts.Queries;

public record GetAccountByUidQuery(Guid Uid) :  IQuery<Result<AccountDTO?>>;

public class GetAccountByUidQueryHandler(IAccountQueries accountQueries) : IQueryHandler<GetAccountByUidQuery, Result<AccountDTO?>>
{
    public async Task<Result<AccountDTO?>> Handle(GetAccountByUidQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var users = await accountQueries.GetAccountByUid(query.Uid, cancellationToken);
        return Result<AccountDTO?>.Success(users);
    }
}