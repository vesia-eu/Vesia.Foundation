using Application.Common;
using Application.Contracts.Queries;
using Application.Features.Accounts.DTOs;
using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;

namespace Application.Features.Accounts.Queries;

public record GetAccountByUidQuery(Guid Uid) :  IQuery<Result<AccountDTO?>>;

public class GetAccountByUidQueryHandler(IAccountQueries accountQueries) : IQueryHandler<GetAccountByUidQuery, Result<AccountDTO?>>
{
    public async Task<Result<AccountDTO?>> Handle(GetAccountByUidQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var users = await accountQueries.GetAccountByUid(query.Uid, cancellationToken);
        return Result<AccountDTO?>.Success(users);
    }
}