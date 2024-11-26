using MovieAppApi.Src.Core.Services.Environment;
using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.FetchMovies.Tmdb;

public class TmdbService : IFetchMoviesService
{
  private readonly HttpClient _httpClient;
  private readonly string _apiKey;
  private readonly string _baseUrl;

  public TmdbService(HttpClient httpClient, IEnvService envService)
  {
    _httpClient = httpClient;
    _apiKey = envService.Vars.TmdbApiKey;
    _baseUrl = "https://api.themoviedb.org/3";
  }

  public async Task<SearchMoviesResultModel> SearchMoviesAsync(SearchMoviesRequestQueryModel query)
  {
    var url = $"{_baseUrl}/search/movie?api_key={_apiKey}&query={query.SearchTerm}&language={query.Language}";
    var response = await _httpClient.GetAsync(url);
    response.EnsureSuccessStatusCode();

    var content = await response.Content.ReadFromJsonAsync<TmdbSearchMoviesResultDto>();
    if (content == null)
    {
      throw new Exception("Tmdb API: /search/movie returned null");
    }

    return content.ToModel();
  }
}
