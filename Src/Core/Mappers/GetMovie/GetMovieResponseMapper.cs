using MovieAppApi.Src.Models.Movie;
using MovieAppApi.Src.Views.DTO.Movie;

namespace MovieAppApi.Src.Core.Mappers.GetMovie;

public class GetMovieResponseMapper : IGetMovieResponseMapper
{
  public MovieDto ToDto(MovieModel model)
  {
    return new MovieDto
    {
      id = model.Id,
      original_language = model.OriginalLanguage,
      original_title = model.OriginalTitle,
      title = model.Title,
      overview = model.Overview,
      release_date = model.ReleaseDate,
      vote_average = model.VoteAverage,
      vote_count = model.VoteCount,
      popularity = model.Popularity,
      poster_path = model.PosterPath,
    };
  }
}