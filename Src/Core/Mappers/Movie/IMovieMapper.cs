using MovieAppApi.Src.Models.Movie;
using MovieAppApi.Src.Views.DTO.Movie;

namespace MovieAppApi.Src.Core.Mappers.Movie;

public interface IMovieMapper
{
  public MovieDto FromModelToDto(MovieModel model);
}