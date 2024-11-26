using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Src.Views.DTO.SearchMovies;

namespace MovieAppApi.Src.Controllers;

public class MoviesController : BaseController<MoviesController>
{
  public MoviesController(ILogger<MoviesController> logger) : base(logger)
  {
  }

  [HttpGet]
  public async Task<IActionResult> SearchMoviesAsync([FromQuery] SearchMoviesRequestQueryDto queryDto)
  {
    return Ok("Ok");
  }
}