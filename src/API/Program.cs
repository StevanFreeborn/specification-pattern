var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

var app = builder.Build();

using var scope = app.Services.CreateAsyncScope();
using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await context.Database.MigrateAsync();


app.MapGet(
  "/movies", 
  async (
    IMovieRepository repository, 
    [FromQuery] int minRating = 0, 
    [FromQuery] bool forKids = false, 
    [FromQuery] bool onCd = false,
    [FromQuery] int page = 0,
    [FromQuery] int pageSize = 10,
    [FromQuery] string name = ""
  ) =>
  {
    var spec = Specification<Movie>.All;

    if (forKids)
    {
      spec = spec.And(new MovieForKidsSpecification());
    }

    if (onCd)
    {
      spec = spec.And(new AvailableOnCDSpecification());
    }

    if (name is not "")
    {
      spec = spec.And(new MovieDirectedBySpecification(name));
    }

    var movies = await repository.GetAllAsync(spec, minRating, page, pageSize);
    var dtos = movies.Select(movie => new MovieDto(
      movie.Id,
      movie.Name,
      movie.ReleaseDate,
      movie.MpaaRating,
      movie.Genre,
      movie.Rating,
      movie.DirectorId,
      new(movie.Director.Id, movie.Director.Name)
    ));

    return Results.Ok(dtos);
  }
);

app.MapPost(
  "/movies/{id}/ticket", 
  async (IMovieRepository repository, [FromRoute] long id, [FromBody] PurchaseRequest purchaseRequest) =>
  {
    var movie = await repository.GetAsync(id);
    
    if (movie is null)
    {
      return Results.NotFound();
    }

    var childSpecification = new MovieForKidsSpecification();

    if (purchaseRequest.TicketType is "child" && childSpecification.IsSatisfiedBy(movie) is false)
    {
      return Results.BadRequest(new { Error = "This movie is not kid-friendly." });
    }

    var cdSpecification = new AvailableOnCDSpecification();

    if (purchaseRequest.TicketType is "cd" && cdSpecification.IsSatisfiedBy(movie) is false)
    {
      return Results.BadRequest(new { Error = "This movie is not available on CD." });
    }

    return Results.Ok(new { Ticket = Guid.NewGuid() });
  }
);

app.UseSwagger();
app.UseSwaggerUI(o => 
{
  o.RoutePrefix = string.Empty;
  o.SwaggerEndpoint("swagger/v1/swagger.json", "Movies API");
});

app.UseHttpsRedirection();

app.Run();

record PurchaseRequest(
  string TicketType
);

record MovieDto(
  long Id,
  string Name,
  DateTime ReleaseDate,
  MpaaRating MpaaRating,
  string Genre,
  double Rating,
  long DirectorId,
  MovieDto.DirectorDto Director
)
{
  public record DirectorDto(
    long Id,
    string Name
  );
}