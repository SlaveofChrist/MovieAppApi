namespace MovieAppApi.Src.Views.DTO.Movie;

public class MovieDto
{
  public required int id { get; init; }
  public required string original_language { get; init; }
  public required string original_title { get; init; }
  public required string overview { get; init; }
  public required double popularity { get; init; }
  public required DateTime release_date { get; init; }
  public required string title { get; init; }
  public required double vote_average { get; init; }
  public required int vote_count { get; init; }
  public string? poster_path { get; init; }
}