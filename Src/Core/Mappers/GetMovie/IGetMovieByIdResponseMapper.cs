
using MovieAppApi.Src.Models.Movie;
using MovieAppApi.Src.Views.DTO.Movie;

namespace MovieAppApi.Src.Core.Mappers.GetMovie;

public interface IGetMovieByIdResponseMapper
{
  public MovieDto ToDto(MovieModel model);
}