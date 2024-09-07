namespace Logic.Utils;

public class GenericSpecification<T>(Expression<Func<T, bool>> criteria)
{
  public Expression<Func<T, bool>> Criteria { get; } = criteria;

  public bool IsSatisfiedBy(T entity)
  {
    return Criteria.Compile().Invoke(entity);
  }
}