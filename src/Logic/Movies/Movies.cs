namespace Logic.Movies;

public class Movie : Entity
{
  public virtual string Name { get; } = string.Empty;
  public virtual DateTime ReleaseDate { get; }
  public virtual MpaaRating MpaaRating { get; }
  public virtual string Genre { get; } = string.Empty;
  public virtual double Rating { get; }

  protected Movie()
  {
  }

  public Movie(long id, string name, DateTime releaseDate, MpaaRating mpaaRating, string genre, double rating)
  {
    Id = id;
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