using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

public interface ISearchMoviesRequestQueryMapper
{
  public SearchMoviesRequestQueryModel FromDtoToModel(SearchMoviesRequestQueryDto dto);
}
