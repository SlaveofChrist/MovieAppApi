namespace MovieAppApi.Src.Core.Exceptions;

public class SearchMoviesNullException : Exception
{
  public SearchMoviesNullException(string? customMessage) : base(customMessage ?? "SearchMovies response is null")
  {
  }
}