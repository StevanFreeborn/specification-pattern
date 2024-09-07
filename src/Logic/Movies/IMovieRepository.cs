namespace Logic.Movies;

public interface IMovieRepository
{
  Task<Movie?> GetAsync(long id);
  Task<IReadOnlyList<Movie>> GetAllAsync(Specification<Movie> specification);
}