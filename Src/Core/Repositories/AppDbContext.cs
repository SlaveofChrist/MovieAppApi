using Microsoft.EntityFrameworkCore;
using MovieAppApi.Src.Core.Repositories.Entities;

namespace MovieAppApi.Src.Core.Repositories;

public class AppDbContext : DbContext
{
  public required DbSet<MovieEntity> Movies { get; set; }
  public required DbSet<PlaylistEntity> Playlists { get; set; }
  public required DbSet<PlaylistJoinMovieEntity> PlaylistJoinMovies { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<PlaylistJoinMovieEntity>().HasKey(e => new { e.PlaylistId, e.MovieId });
  }
}