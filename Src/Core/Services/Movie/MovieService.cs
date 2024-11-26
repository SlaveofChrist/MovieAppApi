using MovieAppApi.Src.Core.Services.FetchMovies;
using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.Movie;

public class MovieService : IMovieService
{
  private readonly IFetchMoviesService _fetchMoviesService;

  public MovieService(IFetchMoviesService fetchMoviesService)
  {
    _fetchMoviesService = fetchMoviesService;
  }

  public Task<SearchMoviesResultModel> SearchMoviesAsync(SearchMoviesRequestQueryModel query)
  {
    return _fetchMoviesService.SearchMoviesAsync(query);
  }
}