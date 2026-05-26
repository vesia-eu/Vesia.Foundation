using Application.Contracts.Queries;
using Application.Features.Accounts.DTOs;
using Application.Features.Accounts.Queries;
using NSubstitute;

namespace Application.Tests.Accounts.Queries;

public class GetAllAccountsQueryHandlerTests
{
    private readonly IAccountQueries _accountQueries = Substitute.For<IAccountQueries>();
    private readonly GetUsersRequiringSyncHandler _handler;

    public GetAllAccountsQueryHandlerTests()
    {
        _handler = new GetUsersRequiringSyncHandler(_accountQueries);
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccess_WithAccounts()
    {
        var accounts = new List<AccountDTO>
        {
            new(Guid.NewGuid(), "john_doe", "john@example.com", "John", "Doe", null)
        };

        _accountQueries.GetAllAccountsQuery(Arg.Any<CancellationToken>())
            .Returns(accounts);

        var result = await _handler.Handle(new GetAllAccountsQuery(), CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value);
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccess_WithEmptyList_WhenNoAccountsExist()
    {
        _accountQueries.GetAllAccountsQuery(Arg.Any<CancellationToken>())
            .Returns(new List<AccountDTO>());

        var result = await _handler.Handle(new GetAllAccountsQuery(), CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value);
    }
}