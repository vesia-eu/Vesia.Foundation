namespace Vesia.Template.Domain.Common;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetAtomicValues();
        
    public override bool Equals(object? obj) =>
        obj is ValueObject vo && ValuesAreEqual(vo);
        
    private bool ValuesAreEqual(ValueObject other) =>
        GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        
    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(1, (current, obj) => 
                unchecked(current * 31 + (obj?.GetHashCode() ?? 0)));
}