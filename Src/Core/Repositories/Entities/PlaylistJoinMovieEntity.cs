namespace MovieAppApi.Src.Core.Repositories.Entities;

public class PlaylistJoinMovieEntity : CommonEntity
{
  public int PlaylistId { get; set; }
  public required PlaylistEntity Playlist { get; set; }

  public int MovieId { get; set; }
  public required MovieEntity Movie { get; set; }

}