using MovieAppApi.Src.Models.Movie;

namespace MovieAppApi.Src.Models.SearchMovies
{
  public class SearchMoviesResultModel
  {

    public int Page { get; }
    public List<MovieModel> Results { get; }
    public int TotalPages { get; }
    public int TotalResults { get; }

    public SearchMoviesResultModel(int page, List<MovieModel> movieModels, int total_pages, int total_results)
    {
      Page = page;
      Results = movieModels;
      TotalPages = total_pages;
      TotalResults = total_results;
    }
  }
}
