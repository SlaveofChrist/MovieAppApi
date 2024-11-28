using Microsoft.EntityFrameworkCore;
using MovieAppApi.Src.Core.Exceptions;
using MovieAppApi.Src.Core.Repositories.Entities;
using MovieAppApi.Src.Models.CreatePlaylist;
using MovieAppApi.Src.Models.Playlist;

namespace MovieAppApi.Src.Core.Repositories.Playlist;


public class PlaylistRepository : IPlaylistRepository
{
  private readonly AppDbContext _appDbContext;

  public PlaylistRepository(AppDbContext appDbContext)
  {
    _appDbContext = appDbContext;
  }

  public async Task<PlaylistModel> CreatePlaylistAsync(CreatePlaylistRequestBodyModel data)
  {
    // Prepare the join entities getting the movies from the database or creating new ones
    var playlistJoinMovieEntities = await Task.WhenAll(data.MovieIds.Select(async id =>
    new PlaylistJoinMovieEntity
    {
      Movie = await _appDbContext.Movies.FindAsync(id) ?? new MovieEntity
      {
        Id = id,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
      },
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow
    }));

    var playlistEntity = new PlaylistEntity
    {
      Name = data.Name,
      Description = data.Description,
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow,
      PlaylistJoinMovies = playlistJoinMovieEntities.ToList()
    };

    await _appDbContext.Playlists.AddAsync(playlistEntity);
    await _appDbContext.SaveChangesAsync();

    return new PlaylistModel(
      id: playlistEntity.Id,
      name: playlistEntity.Name,
      description: playlistEntity.Description,
      movieIds: playlistEntity.PlaylistJoinMovies.Select(p => p.MovieId).ToList()
    );
  }

  public async Task<List<PlaylistModel>> GetPlaylistsAsync()
  {
    var playlistEntities = await _appDbContext.Playlists
      .Include(p => p.PlaylistJoinMovies)
      .ThenInclude(p => p.Movie)
      .ToListAsync();

    var playlistModels = playlistEntities.Select(playlistEntity => new PlaylistModel(
      id: playlistEntity.Id,
      name: playlistEntity.Name,
      description: playlistEntity.Description,
      movieIds: playlistEntity.PlaylistJoinMovies.Select(p => p.MovieId).ToList()
    )).ToList();

    return playlistModels;
  }

  public async Task<PlaylistModel> GetPlaylistAsync(int playlistId)
  {
    var playlistEntity = await _appDbContext.Playlists
      .Include(p => p.PlaylistJoinMovies)
      .ThenInclude(p => p.Movie)
      .FirstOrDefaultAsync(p => p.Id == playlistId);

    if (playlistEntity == null)
    {
      throw new PlaylistNotFoundException(playlistId);
    }

    return new PlaylistModel(
      id: playlistEntity.Id,
      name: playlistEntity.Name,
      description: playlistEntity.Description,
      movieIds: playlistEntity.PlaylistJoinMovies.Select(p => p.MovieId).ToList()
    );
  }
}
