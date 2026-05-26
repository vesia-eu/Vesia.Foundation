using Application.Common;
using Application.Contracts.Repositories;
using Application.Features.Accounts.Commands;
using Domain.AccountManagement.AggragateRoot;
using NSubstitute;

namespace Application.Tests.Accounts.Commands;

public class CreateAccountCommandHandlerTests
{
    private readonly IAccountRepository _accountRepository = Substitute.For<IAccountRepository>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly CreateAccountCommandHandler _handler;

    public CreateAccountCommandHandlerTests()
    {
        _handler = new CreateAccountCommandHandler(_accountRepository, _unitOfWork);
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccess_WhenAccountIsCreated()
    {
        var command = new CreateAccountCommand("john_doe", "john@example.com", "John", "Doe");

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotEqual(Guid.Empty, result.Value);
    }

    [Fact]
    public async Task Handle_ShouldAddAccountToRepository()
    {
        var command = new CreateAccountCommand("john_doe", "john@example.com", "John", "Doe");

        await _handler.Handle(command, CancellationToken.None);

        _accountRepository.Received(1).Add(Arg.Any<Account>());
    }

    [Fact]
    public async Task Handle_ShouldSaveChanges()
    {
        var command = new CreateAccountCommand("john_doe", "john@example.email", "John", "Doe");

        await _handler.Handle(command, CancellationToken.None);

        await _unitOfWork.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}