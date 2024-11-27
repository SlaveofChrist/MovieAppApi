using System.ComponentModel.DataAnnotations;

namespace MovieAppApi.Src.Core.Repositories.Entities;

public class MovieEntity : CommonEntity
{
  [Key]
  public required int Id { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "TmdbId must be at least 1.")]
  public required int TmdbId { get; set; }

  [Required(AllowEmptyStrings = false)]
  public required string OriginalLanguage { get; set; }

  public required List<PlaylistJoinMovieEntity> PlaylistJoinMovies { get; set; }
}