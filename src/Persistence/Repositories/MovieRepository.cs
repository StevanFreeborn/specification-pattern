namespace Persistence.Repositories;

public class MovieRepository(AppDbContext context) : IMovieRepository
{
  private readonly AppDbContext _context = context;

  public async Task<IReadOnlyList<Movie>> GetAllAsync(
    Specification<Movie> specification, 
    int minRating,
    int page,
    int pageSize
  )
  {
    var whereExpression = specification.ToExpression();

    return await _context.Movies
      .Where(whereExpression)
      .Where(movie => movie.Rating >= minRating)
      .Skip(page * pageSize)
      .Take(pageSize)
      .Include(movie => movie.Director)
      .ToListAsync();
  }

  public async Task<Movie?> GetAsync(long id)
  {
    return await _context.Movies.FindAsync(id);
  }
}