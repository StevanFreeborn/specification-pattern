namespace Logic.Movies;

public sealed class MovieForKidsSpecification : Specification<Movie>
{
  public override Expression<Func<Movie, bool>> ToExpression()
  {
    return movie => movie.MpaaRating <= MpaaRating.PG;
  }
}