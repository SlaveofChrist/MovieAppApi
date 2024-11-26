namespace MovieAppApi.Src.Models.SearchMovies;

public class SearchMoviesRequestQueryModel
{
  public required string SearchTerm { get; init; }
  public required string Language { get; init; }
}