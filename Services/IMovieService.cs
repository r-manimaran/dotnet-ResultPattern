namespace dotnet_ResultPattern;
using dotnet_ResultPattern.Models;

public interface IMovieService
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<Movie> CreateMovieAsync(CreateMovieRequest movie);
}
