using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Src.Core.Mappers.SearchMovies;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Controllers;

public class MoviesController : BaseController<MoviesController>
{
  private readonly ISearchMoviesRequestQueryMapper _searchMoviesRequestQueryMapper;
  public MoviesController(ILogger<MoviesController> logger, ISearchMoviesRequestQueryMapper searchMoviesRequestQueryMapper) : base(logger)
  {
    _searchMoviesRequestQueryMapper = searchMoviesRequestQueryMapper;
  }

  [HttpGet]
  public async Task<IActionResult> SearchMoviesAsync([FromQuery] SearchMoviesRequestQueryDto queryDto)
  {
    var queryModel = _searchMoviesRequestQueryMapper.ToModel(queryDto);

    return Ok("Ok");
  }
}