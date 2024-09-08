namespace Logic.Movies;

public class Movie : Entity
{
  public virtual string Name { get; } = string.Empty;
  public virtual DateTime ReleaseDate { get; }
  public virtual MpaaRating MpaaRating { get; }
  public virtual string Genre { get; } = string.Empty;
  public virtual double Rating { get; }
  public virtual long DirectorId { get; set; }
  public virtual Director Director { get; set; } = null!;

  protected Movie()
  {
  }

  public Movie(long id, long directorId, string name, DateTime releaseDate, MpaaRating mpaaRating, string genre, double rating)
  {
    Id = id;
    DirectorId = directorId;
    Name = name;
    ReleaseDate = releaseDate;
    MpaaRating = mpaaRating;
    Genre = genre;
    Rating = rating;
  }
}

public enum MpaaRating
{
  G,
  PG,
  PG13,
  R,
  NC17
}