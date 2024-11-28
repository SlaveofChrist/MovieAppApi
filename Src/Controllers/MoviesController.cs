using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Src.Core.Mappers.SearchMovies;
using MovieAppApi.Src.Core.Services.Movie;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Controllers;

public class MoviesController : BaseController<MoviesController>
{
  private readonly ISearchMoviesRequestQueryMapper _searchMoviesRequestQueryMapper;

  private readonly ISearchMoviesResponseMapper _searchMoviesResponseMapper;

  private readonly IMovieService _movieService;

  public MoviesController(ILogger<MoviesController> logger,
    ISearchMoviesRequestQueryMapper searchMoviesRequestQueryMapper,
    ISearchMoviesResponseMapper searchMoviesResponseMapper,
    IMovieService movieService) : base(logger)
  {
    _searchMoviesRequestQueryMapper = searchMoviesRequestQueryMapper;
    _searchMoviesResponseMapper = searchMoviesResponseMapper;
    _movieService = movieService;
  }

  [HttpGet]
  public async Task<IActionResult> SearchMoviesAsync([FromQuery] SearchMoviesRequestQueryDto queryDto)
  {
    var queryModel = _searchMoviesRequestQueryMapper.ToModel(queryDto);

    var result = await _movieService.SearchMoviesAsync(queryModel);

    var dto = _searchMoviesResponseMapper.ToDto(result);

    return Ok(dto);
  }
}