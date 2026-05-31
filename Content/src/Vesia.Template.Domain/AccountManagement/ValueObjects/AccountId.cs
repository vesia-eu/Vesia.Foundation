using Vesia.Template.Domain.Common;

namespace Vesia.Template.Domain.AccountManagement.ValueObjects;

public class AccountId : ValueObject
{
    public Guid Value { get; }

    private AccountId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("AccountId cannot be empty", nameof(value));

        Value = value;
    }

    public static AccountId Create() => new(Guid.NewGuid());
    public static AccountId From(Guid value) => new(value);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();

    //Use AccountId and Guid interchangeably without explicit casting
    public static implicit operator Guid(AccountId accountId) => accountId.Value;
    public static implicit operator AccountId(Guid value) => new(value);
}