namespace Persistence;

public class AppDbContext : DbContext
{
  public DbSet<Movie> Movies { get; set; } = null!;
  private SqliteConnection? _connection;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var folder = Assembly.GetExecutingAssembly().Location;
    var path = Path.GetDirectoryName(folder);
    var dataDir = Path.Combine(path!, "Data");

    if (Directory.Exists(dataDir) is false)
    {
      Directory.CreateDirectory(dataDir);
    }

    var dbPath = Path.Combine(dataDir, "app.db");

    _connection = new SqliteConnection($"Data Source={dbPath}");
    _connection.Open();

    optionsBuilder.UseSqlite(_connection);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>().ToTable("Movies");
    modelBuilder.Entity<Movie>().HasKey(m => m.Id);
    modelBuilder.Entity<Movie>().Property(m => m.Name).IsRequired();
    modelBuilder.Entity<Movie>().Property(m => m.ReleaseDate).IsRequired();
    modelBuilder.Entity<Movie>().Property(m => m.MpaaRating).IsRequired();
    modelBuilder.Entity<Movie>().Property(m => m.Genre).IsRequired();
    modelBuilder.Entity<Movie>().Property(m => m.Rating).IsRequired();

    modelBuilder.Entity<Movie>().HasData(
        new Movie(1, "The Matrix", new DateTime(1999, 3, 31), MpaaRating.R, "Sci-Fi", 8.7),
        new Movie(2, "Inception", new DateTime(2010, 7, 16), MpaaRating.PG13, "Sci-Fi", 8.8),
        new Movie(3, "The Lion King", new DateTime(1994, 6, 24), MpaaRating.G, "Animation", 8.5),
        new Movie(4, "Pulp Fiction", new DateTime(1994, 10, 14), MpaaRating.R, "Crime", 8.9),
        new Movie(5, "Forrest Gump", new DateTime(1994, 7, 6), MpaaRating.PG13, "Drama", 8.8),
        new Movie(6, "Toy Story", new DateTime(1995, 11, 22), MpaaRating.G, "Animation", 8.3),
        new Movie(7, "The Dark Knight", new DateTime(2008, 7, 18), MpaaRating.PG13, "Action", 9.0),
        new Movie(8, "Fight Club", new DateTime(1999, 10, 15), MpaaRating.R, "Drama", 8.8),
        new Movie(9, "The Godfather", new DateTime(1972, 3, 24), MpaaRating.R, "Crime", 9.2),
        new Movie(10, "The Shawshank Redemption", new DateTime(1994, 9, 23), MpaaRating.R, "Drama", 9.3)
      );
  }

  public async override ValueTask DisposeAsync()
  {
    if (_connection is not null)
    {
      await _connection.DisposeAsync();
    }

    await base.DisposeAsync();
  }
}