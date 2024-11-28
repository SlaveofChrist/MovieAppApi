using MovieAppApi.Src.Models.Movie;
using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.Movie;

public interface IMovieService
{
  public Task<SearchMoviesResultModel> SearchMoviesAsync(SearchMoviesRequestQueryModel query);
  public Task<MovieModel> GetMovieAsync(int movieId, string language);
}