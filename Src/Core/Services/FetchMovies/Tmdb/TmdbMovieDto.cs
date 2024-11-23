using System.ComponentModel.DataAnnotations;
using MovieAppApi.Src.Models.Movie;

namespace MovieAppApi.Src.Core.Services.FetchMovies.Tmdb;

public class TmdbMovieDto
{
  [Required] public int id { get; }
  [Required] public string original_language { get; }
  [Required] public string original_title { get; }
  [Required] public string overview { get; }
  [Required] public double popularity { get; }
  [Required] public DateTime release_date { get; }
  [Required] public string title { get; }
  [Required] public double vote_average { get; }
  [Required] public int vote_count { get; }
  public string? poster_path { get; }


  public TmdbMovieDto(
    int id,
    string original_language,
    string original_title,
    string overview,
    double popularity,
    DateTime release_date,
    string title,
    double vote_average,
    int vote_count,
    string? poster_path
  )
  {
    this.id = id;
    this.original_language = original_language;
    this.original_title = original_title;
    this.overview = overview;
    this.popularity = popularity;
    this.release_date = release_date;
    this.title = title;
    this.vote_average = vote_average;
    this.vote_count = vote_count;
    this.poster_path = poster_path;
    Validator.ValidateObject(this, new ValidationContext(this), true);
  }

  public MovieModel ToModel()
  {
    return new MovieModel(
      id: id,
      originalLanguage: original_language,
      originalTitle: original_title,
      overview: overview,
      popularity: popularity,
      releaseDate: release_date,
      title: title,
      voteAverage: vote_average,
      voteCount: vote_count,
      posterPath: poster_path
    );
  }
}
