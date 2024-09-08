namespace Logic.Movies;

public sealed class MovieDirectedBySpecification : Specification<Movie>
{
  private readonly string _directorName;

  public MovieDirectedBySpecification(string directorName)
  {
    _directorName = directorName;
  }

  public override Expression<Func<Movie, bool>> ToExpression()
  {
    return movie => movie.Director.Name == _directorName;
  }
}