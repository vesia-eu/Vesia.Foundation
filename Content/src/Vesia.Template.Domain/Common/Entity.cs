namespace Vesia.Template.Domain.Common;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;

    protected Entity() { }
    protected Entity(TId id) => Id = id;

    public override bool Equals(object? obj) =>
        obj is Entity<TId> entity && (Id?.Equals(entity.Id) ?? false);

    public override int GetHashCode() => Id?.GetHashCode() ?? 0;
}