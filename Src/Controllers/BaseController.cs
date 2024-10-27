using Microsoft.AspNetCore.Mvc;

namespace MovieAppApi.Src.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BaseController<T> : Controller
  {
    protected readonly ILogger<T> _logger;

    public BaseController(ILogger<T> logger)
    {
      _logger = logger;
    }
  }
}