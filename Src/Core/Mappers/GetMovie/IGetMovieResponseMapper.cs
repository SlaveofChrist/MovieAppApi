using MovieAppApi.Src.Models.Movie;
using MovieAppApi.Src.Views.DTO.Movie;

namespace MovieAppApi.Src.Core.Mappers.GetMovie;

public interface IGetMovieResponseMapper
{
  public MovieDto ToDto(MovieModel model);
}