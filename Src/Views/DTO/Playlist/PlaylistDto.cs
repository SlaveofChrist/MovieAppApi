namespace MovieAppApi.Src.Views.DTO.Playlist;

public class PlaylistDto
{
  public required int id { get; init; }
  public required string name { get; init; }
  public required string description { get; init; }
  public required List<int> movie_ids { get; init; }
}