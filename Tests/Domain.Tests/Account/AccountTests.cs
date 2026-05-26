using Domain.AccountManagement.AggragateRoot;
using Domain.AccountManagement.Events;
using Domain.AccountManagement.ValueObjects;

namespace Domain.Tests;

public class AccountTests
{
    private static Account CreateTestAccount() =>
        Account.Create(AccountId.Create(), "john_doe", "john@example.com", "John", "Doe");

    [Fact]
    public void Create_ShouldRaiseDomainEvent_WhenAccountIsCreated()
    {
        var account = CreateTestAccount();

        Assert.Single(account.DomainEvents);
        Assert.IsType<AccountCreatedEvent>(account.DomainEvents.First());
    }

    [Fact]
    public void Create_ShouldSetProperties_WhenAccountIsCreated()
    {
        var account = CreateTestAccount();

        Assert.Equal("john_doe", account.AccountName);
        Assert.Equal("john@example.com", account.Email);
        Assert.Equal("John", account.FirstName);
        Assert.Equal("Doe", account.LastName);
        Assert.Null(account.ValidTo);
        Assert.Null(account.LastModifiedAt);
    }

    [Fact]
    public void UpdateFirstName_ShouldUpdateFirstName_AndRaiseDomainEvent()
    {
        var account = CreateTestAccount();
        account.ClearDomainEvents();

        account.UpdateFirstName("Jane");

        Assert.Equal("Jane", account.FirstName);
        Assert.NotNull(account.LastModifiedAt);
        Assert.Single(account.DomainEvents);
        Assert.IsType<AccountUpdatedEvent>(account.DomainEvents.First());
    }

    [Fact]
    public void UpdateLastName_ShouldUpdateLastName_AndRaiseDomainEvent()
    {
        var account = CreateTestAccount();
        account.ClearDomainEvents();

        account.UpdateLastName("Smith");

        Assert.Equal("Smith", account.LastName);
        Assert.NotNull(account.LastModifiedAt);
        Assert.Single(account.DomainEvents);
        Assert.IsType<AccountUpdatedEvent>(account.DomainEvents.First());
    }

    [Fact]
    public void Deactivate_ShouldSetValidTo_AndRaiseDomainEvent()
    {
        var account = CreateTestAccount();
        account.ClearDomainEvents();

        account.Deactivate();

        Assert.NotNull(account.ValidTo);
        Assert.NotNull(account.LastModifiedAt);
        Assert.Single(account.DomainEvents);
        Assert.IsType<AccountDeactivatedEvent>(account.DomainEvents.First());
    }

    [Fact]
    public void Deactivate_ShouldSetValidTo_ToApproximatelyNow()
    {
        var account = CreateTestAccount();
        var before = DateTime.UtcNow;

        account.Deactivate();

        Assert.True(account.ValidTo >= before);
        Assert.True(account.ValidTo <= DateTime.UtcNow);
    }
}