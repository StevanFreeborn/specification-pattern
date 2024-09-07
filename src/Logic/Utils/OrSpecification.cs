
namespace Logic.Utils;

internal sealed class OrSpecification<T> : Specification<T>
{
  private readonly Specification<T> _left;
  private readonly Specification<T> _right;

  public OrSpecification(Specification<T> left, Specification<T> right)
  {
    _left = left;
    _right = right;
  }

  public override Expression<Func<T, bool>> ToExpression()
  {
    var leftExpression = _left.ToExpression();
    var rightExpression = _right.ToExpression();

    var paramExpression = Expression.Parameter(typeof(T));
    var expressionBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
    var orExpression = (BinaryExpression)new ParameterReplacer(paramExpression).Visit(expressionBody);

    return Expression.Lambda<Func<T, bool>>(orExpression, paramExpression);
  }
}