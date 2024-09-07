namespace Logic.Utils;

internal sealed class IdentitySpecification<T> : Specification<T>
{
  public override Expression<Func<T, bool>> ToExpression()
  {
    return x => true;
  }
}