
namespace Logic.Utils;

internal sealed class NotSpecification<T> : Specification<T>
{
  private readonly Specification<T> _spec;

  public NotSpecification(Specification<T> spec)
  {
    _spec = spec;
  }

  public override Expression<Func<T, bool>> ToExpression()
  {
    var expression = _spec.ToExpression();
    var notExpression = Expression.Not(expression.Body);

    return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
  }
}