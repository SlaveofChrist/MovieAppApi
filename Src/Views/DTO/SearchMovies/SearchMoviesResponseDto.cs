using MovieAppApi.Src.Views.DTO.Movie;

namespace MovieAppApi.Src.Views.DTO.SearchMovies;

public class SearchMoviesResponseDto
{
  public required int page { get; init; }

  public required List<MovieDto> results { get; init; }

  public required int total_pages { get; init; }

  public required int total_results { get; init; }
}