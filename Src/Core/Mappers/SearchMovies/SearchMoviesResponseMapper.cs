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
      total_results = model.TotalResults,
      total_pages = model.TotalPages,
      results = model.Results.Select(movieModel => new MovieDto
      {
        id = movieModel.Id,
        original_language = movieModel.OriginalLanguage,
        original_title = movieModel.OriginalTitle,
        title = movieModel.Title,
        overview = movieModel.Overview,
        release_date = movieModel.ReleaseDate,
        vote_average = movieModel.VoteAverage,
        vote_count = movieModel.VoteCount,
        popularity = movieModel.Popularity,
        poster_path = movieModel.PosterPath,
      }).ToList()
    };
  }
}