using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Src.Core.Exceptions;
using MovieAppApi.Src.Core.Mappers.GetMovie;
using MovieAppApi.Src.Core.Mappers.SearchMovies;
using MovieAppApi.Src.Core.Services.Movie;
using MovieAppApi.Src.Views.DTO.GetMovie;
using MovieAppApi.Src.Views.DTO.Movie;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Controllers;

public class MoviesController : BaseController<MoviesController>
{
  private readonly ISearchMoviesRequestQueryMapper _searchMoviesRequestQueryMapper;

  private readonly ISearchMoviesResponseMapper _searchMoviesResponseMapper;
  private readonly IGetMovieByIdResponseMapper _getMovieByIdResponseMapper;

  private readonly IMovieService _movieService;

  public MoviesController(ILogger<MoviesController> logger,
    ISearchMoviesRequestQueryMapper searchMoviesRequestQueryMapper,
    ISearchMoviesResponseMapper searchMoviesResponseMapper,
    IGetMovieByIdResponseMapper getMovieByIdResponseMapper,
    IMovieService movieService) : base(logger)
  {
    _searchMoviesRequestQueryMapper = searchMoviesRequestQueryMapper;
    _searchMoviesResponseMapper = searchMoviesResponseMapper;
    _movieService = movieService;
    _getMovieByIdResponseMapper = getMovieByIdResponseMapper;
  }

  [HttpGet]
  public async Task<ActionResult<SearchMoviesResponseDto>> SearchMoviesAsync([FromQuery] SearchMoviesRequestQueryDto queryDto)
  {
    var queryModel = _searchMoviesRequestQueryMapper.ToModel(queryDto);

    var result = await _movieService.SearchMoviesAsync(queryModel);

    var dto = _searchMoviesResponseMapper.ToDto(result);

    return Ok(dto);
  }

  [HttpGet("{movieId}")]
  public async Task<ActionResult<MovieDto>> GetMovieAsync(int movieId, [FromQuery] GetMovieRequestQueryDto queryDto)
  {
    try
    {
      var result = await _movieService.GetMovieByIdAsync(movieId, queryDto.language);

      var dto = _getMovieByIdResponseMapper.ToDto(result);
      return Ok(dto);
    }
    catch (Exception e)
    {
      if (e is MovieNotFoundException)
      {
        return NotFound($"Movie id {movieId} not found");
      }

      throw;
    }
  }
}