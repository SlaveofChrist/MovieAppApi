using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Src.Core.Services.Environment;

namespace MovieAppApi.Src.Controllers;

public class HealthController : BaseController<HealthController>
{
  public HealthController(ILogger<HealthController> logger, IEnvService _envService) : base(logger)
  {
    var tmdbApiKey = _envService.Vars.TmdbApiKey;
    Console.WriteLine(tmdbApiKey);
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok("Ok");
  }
}