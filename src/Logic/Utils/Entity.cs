namespace Logic.Utils;

public abstract class Entity
{
  public virtual long Id { get; protected set; }

  public override bool Equals(object? obj)
  {
    var other = obj as Entity;

    if (ReferenceEquals(other, null))
    {
      return false;
    }

    if (ReferenceEquals(this, other))
    {
      return true;
    }

    if (GetType() != other.GetType())
    {
      return false;
    }

    if (Id == 0 || other.Id == 0)
    {
      return false;
    }

    return Id == other.Id;
  }

  public override int GetHashCode()
  {
    return (GetType().ToString() + Id).GetHashCode();
  }
}