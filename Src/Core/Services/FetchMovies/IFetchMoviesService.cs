using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.FetchMovies;

public interface IFetchMoviesService
{
  Task<SearchMoviesResultModel> SearchMoviesAsync(SearchMoviesRequestQueryModel query);
}