namespace MovieAppApi.Src.Models.SearchMovies;

public class SearchMoviesRequestQueryModel
{
  public string SearchTerm { get; init; }
  public string Language { get; init; }

  public SearchMoviesRequestQueryModel(string searchTerm, string language)
  {
    SearchTerm = searchTerm;
    Language = language;
  }
}