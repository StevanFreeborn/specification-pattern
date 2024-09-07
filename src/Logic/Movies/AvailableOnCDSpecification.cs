namespace Logic.Movies;

public sealed class AvailableOnCDSpecification : Specification<Movie>
{
  private const int CdReleaseWindowInMonths = 6;

  public override Expression<Func<Movie, bool>> ToExpression()
  {
    return movie => movie.ReleaseDate <= DateTime.Now.AddMonths(CdReleaseWindowInMonths);
  }
}