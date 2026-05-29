using Vesia.Template.Domain.AccountManagement.Events;
using Vesia.Template.Domain.AccountManagement.ValueObjects;
using Vesia.Template.Domain.Common;

namespace Vesia.Template.Domain.AccountManagement.AggragateRoot;

public class Account : AggregateRoot<AccountId>
{
    private Account() { }

    private Account(
        AccountId id,
        string username,
        string email,
        string firstName,
        string lastName) : base(id)
    {
        AccountName = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = DateTime.UtcNow;
        ValidTo = null;
    }

    public string AccountName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }
    public DateTime? ValidTo { get; private set; }

    public static Account Create(
        AccountId id,
        string username,
        string email,
        string firstName,
        string lastName)
    {
        // Could add validation here
        var account = new Account(id, username, email, firstName, lastName);
        account.RaiseDomainEvent(new AccountCreatedEvent(id, username, email));
        return account;
    }

    public void UpdateFirstName(string firstName)
    {
        FirstName = firstName;
        LastModifiedAt = DateTime.UtcNow;
        RaiseDomainEvent(new AccountUpdatedEvent(Id));
    }

    public void UpdateLastName(string lastName)
    {
        LastName = lastName;
        LastModifiedAt = DateTime.UtcNow;
        RaiseDomainEvent(new AccountUpdatedEvent(Id));
    }

    public void Deactivate()
    {
        ValidTo = DateTime.UtcNow;
        LastModifiedAt = DateTime.UtcNow;
        RaiseDomainEvent(new AccountDeactivatedEvent(Id));
    }
}