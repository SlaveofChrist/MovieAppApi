using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

public class SearchMoviesRequestQueryMapper : ISearchMoviesRequestQueryMapper
{
  public SearchMoviesRequestQueryModel ToModel(SearchMoviesRequestQueryDto dto)
  {
    return new SearchMoviesRequestQueryModel
    {
      SearchTerm = dto.search_term,
      Language = dto.language
    };
  }
}
