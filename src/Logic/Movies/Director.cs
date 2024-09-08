namespace Logic.Movies;

public class Director : Entity
{
  public virtual string Name { get; } = string.Empty;
  public ICollection<Movie> Movies { get; } = [];

  public Director(long id, string name)
  {
    Id = id;
    Name = name;
  }
}