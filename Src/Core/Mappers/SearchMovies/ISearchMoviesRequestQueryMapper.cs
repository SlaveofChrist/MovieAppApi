namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

public interface ISearchMoviesRequestQueryMapper
{
  public SearchMoviesRequestQueryModel FromDtoToModel(SearchMoviesRequestQueryDto dto);
}
