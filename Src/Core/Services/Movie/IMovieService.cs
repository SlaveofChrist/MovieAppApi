using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.Movie;

public interface IMovieService
{
  Task<SearchMoviesResultModel> SearchMoviesAsync(SearchMoviesRequestQueryModel query);
}