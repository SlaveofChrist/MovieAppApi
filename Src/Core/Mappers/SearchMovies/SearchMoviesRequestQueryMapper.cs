using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

public class SearchMoviesRequestQueryMapper : ISearchMoviesRequestQueryMapper
{
  public SearchMoviesRequestQueryModel FromDtoToModel(SearchMoviesRequestQueryDto dto)
  {
    return new SearchMoviesRequestQueryModel(searchTerm: dto.searchTerm, language: dto.language);
  }
}
