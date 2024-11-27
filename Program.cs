using MovieAppApi.Src.Core.Services.Environment;
using MovieAppApi.Src.Core.Mappers.SearchMovies;
using MovieAppApi.Src.Core.Services.FetchMovies;
using MovieAppApi.Src.Core.Services.Movie;
using MovieAppApi.Src.Core.Services.FetchMovies.Tmdb;
using MovieAppApi.Src.Core.Middlewares;
using MovieAppApi.Src.Core.Mappers.GetMovie;
using MovieAppApi.Src.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MovieAppApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var envService = new EnvService();
        builder.Services.AddSingleton<IEnvService>(envService);

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={envService.Vars.DatabaseUrl}"));

        builder.Services.AddScoped<ISearchMoviesRequestQueryMapper, SearchMoviesRequestQueryMapper>();
        builder.Services.AddScoped<ISearchMoviesResponseMapper, SearchMoviesResponseMapper>();
        builder.Services.AddScoped<IGetMovieResponseMapper, GetMovieResponseMapper>();

        builder.Services.AddTransient<HttpClient>();
        builder.Services.AddTransient<IFetchMoviesService, TmdbService>();
        builder.Services.AddTransient<IMovieService, MovieService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
