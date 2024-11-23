using System.ComponentModel.DataAnnotations;
using MovieAppApi.Src.Models.SearchMovies;

namespace MovieAppApi.Src.Core.Services.FetchMovies.Tmdb;

public class TmdbSearchMoviesResultDto
{
    [Required] public int page { get; }
    [Required] public List<TmdbMovieDto> results { get; }
    [Required] public int total_pages { get; }
    [Required] public int total_results { get; }

    public TmdbSearchMoviesResultDto(
        int page,
        List<TmdbMovieDto> results,
        int total_pages,
        int total_results
    )
    {
        this.page = page;
        this.results = results;
        this.total_pages = total_pages;
        this.total_results = total_results;
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }

    public SearchMoviesResultModel ToModel()
    {
        return new SearchMoviesResultModel(
            page,
            results.Select(x => x.ToModel()).ToList(),
            total_pages,
            total_results
        );
    }
}