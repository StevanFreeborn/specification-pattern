
namespace Logic.Utils;

internal sealed class AndSpecification<T> : Specification<T>
{
  private readonly Specification<T> _left;
  private readonly Specification<T> _right;

  public AndSpecification(Specification<T> left, Specification<T> right)
  {
    _left = left;
    _right = right;
  }

  public override Expression<Func<T, bool>> ToExpression()
  {
    var leftExpression = _left.ToExpression();
    var rightExpression = _right.ToExpression();

    var paramExpression = Expression.Parameter(typeof(T));
    var expressionBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
    var andExpression = (BinaryExpression)new ParameterReplacer(paramExpression).Visit(expressionBody);

    return Expression.Lambda<Func<T, bool>>(andExpression, paramExpression);
  }
}