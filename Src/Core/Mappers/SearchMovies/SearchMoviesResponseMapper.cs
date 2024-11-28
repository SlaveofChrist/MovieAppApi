using MovieAppApi.Src.Models.SearchMovies;
using MovieAppApi.Src.Views.DTO.Movie;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Core.Mappers.SearchMovies;

public class SearchMoviesResponseMapper : ISearchMoviesResponseMapper
{
  public SearchMoviesResponseDto ToDto(SearchMoviesResultModel model)
  {
    return new SearchMoviesResponseDto
    {
      page = model.Page,
      total_pages = model.TotalPages,
      total_results = model.TotalResults,
      results = model.Results.Select(movieModel => new MovieDto
      {
        id = movieModel.Id,
        original_language = movieModel.OriginalLanguage,
        original_title = movieModel.OriginalTitle,
        overview = movieModel.Overview,
        popularity = movieModel.Popularity,
        release_date = movieModel.ReleaseDate,
        title = movieModel.Title,
        vote_average = movieModel.VoteAverage,
        vote_count = movieModel.VoteCount,
        poster_path = movieModel.PosterPath
      }).ToList()
    };
  }
}