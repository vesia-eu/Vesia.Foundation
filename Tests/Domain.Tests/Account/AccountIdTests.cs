using Domain.AccountManagement.ValueObjects;

namespace Domain.Tests;

public class AccountIdTests
{
    [Fact]
    public void New_ShouldCreateUniqueIds()
    {
        var id1 = AccountId.Create();
        var id2 = AccountId.Create();

        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void From_ShouldCreateAccountId_FromGuid()
    {
        var guid = Guid.NewGuid();
        var id = AccountId.From(guid);

        Assert.Equal(guid, id.Value);
    }

    [Fact]
    public void From_ShouldThrow_WhenGuidIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => AccountId.From(Guid.Empty));
    }

    [Fact]
    public void TwoIds_WithSameGuid_ShouldBeEqual()
    {
        var guid = Guid.NewGuid();
        var id1 = AccountId.From(guid);
        var id2 = AccountId.From(guid);

        Assert.Equal(id1, id2);
    }
}