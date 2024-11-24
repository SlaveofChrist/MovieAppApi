using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

public interface ISearchMoviesResponseMapper
{
  public SearchMoviesResponseDto FromModelToDto(SearchMoviesResultModel model);
}