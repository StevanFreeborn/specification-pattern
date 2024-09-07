namespace Logic.Utils;

public abstract class Specification<T>
{ 
  public static Specification<T> All => new IdentitySpecification<T>();
  public abstract Expression<Func<T, bool>> ToExpression();

  public bool IsSatisfiedBy(T entity)
  {
    Func<T, bool> predicate = ToExpression().Compile();
    return predicate(entity);
  }

  public Specification<T> And(Specification<T> spec)
  {
    if (this == All)
    {
      return spec;
    }

    if (spec == All)
    {
      return this;
    }
    
    return new AndSpecification<T>(this, spec);
  }

  public Specification<T> Or(Specification<T> spec)
  {
    if (this == All || spec == All)
    {
      return All;
    }

    return new OrSpecification<T>(this, spec);
  }

  public Specification<T> Not()
  {
    return new NotSpecification<T>(this);
  }
}