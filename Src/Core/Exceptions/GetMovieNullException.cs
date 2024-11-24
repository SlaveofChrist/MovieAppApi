namespace MovieAppApi.Src.Core.Exceptions;

public class GetMovieNullException : Exception
{
  public GetMovieNullException(string? customMessage) : base(customMessage ?? "Movie response is null")
  {
  }
}