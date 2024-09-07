using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Repositories;

public class MovieRepository(AppDbContext context) : IMovieRepository
{
  private readonly AppDbContext _context = context;

  public async Task<IReadOnlyList<Movie>> GetAllAsync(Specification<Movie> specification)
  {
    var whereExpression = specification.ToExpression();

    return await _context.Movies
      .Where(whereExpression)
      .ToListAsync();
  }

  public async Task<Movie?> GetAsync(long id)
  {
    return await _context.Movies.FindAsync(id);
  }
}