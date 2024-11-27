using System.ComponentModel.DataAnnotations;

namespace MovieAppApi.Src.Core.Repositories.Entities;

public class PlaylistEntity : CommonEntity
{
  [Key]
  public required int Id { get; set; }

  [Required(AllowEmptyStrings = false)]
  public required string Name { get; set; }

  public string? description { get; set; }
  public required List<PlaylistJoinMovieEntity> PlaylistJoinMovies { get; set; }
}