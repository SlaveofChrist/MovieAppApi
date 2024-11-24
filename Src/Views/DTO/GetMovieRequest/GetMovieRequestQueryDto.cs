using System.ComponentModel.DataAnnotations;

namespace MovieAppApi.Src.Views.DTO.GetMovieRequest;

public class GetMovieRequestQueryDto
{
  [Required, AllowedValues("en", "fr", ErrorMessage = "Invalid language, must be one of: en, fr")]
  public required string language { get; init; }
}