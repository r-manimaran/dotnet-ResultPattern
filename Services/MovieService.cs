using dotnet_ResultPattern.Exceptions;
using dotnet_ResultPattern.Models;

namespace dotnet_ResultPattern.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;
    public MovieService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateMovieAsync(CreateMovieRequest request)
    {
        var errors = ValidateMovieRequest(request);
        if(errors.Any())
        {
            throw new MovieValidationException(errors);
        }

        var movieExists = _context.Movies.Any(x => x.Title == request.Title);
        if(movieExists)
        {
            throw new MovieAlreadyExistsException(request.Title);
        }
        var movie = new Movie
        {
            Title =  request.Title,
            Year = request.Year,
            Genre = request.Genre,       
        };

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public Task<Movie> GetMovieByIdAsync(int id)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
        if(movie == null)
        {
            throw new MovieNotFoundException(id);
        }
        return Task.FromResult(movie);
    }

    private Error[] ValidateMovieRequest(CreateMovieRequest request)
    {
        var errors = new List<Error>();

        if(string.IsNullOrEmpty(request.Title))
        {
            errors.Add(MovieErrors.TitleInvalid);
        }
        if(string.IsNullOrEmpty(request.Genre))
        {
            errors.Add(MovieErrors.GenreInvalid);
        }
        if(request.Year.Year < 1900)
        {
            errors.Add(MovieErrors.YearInvalid);
        }
        return[.. errors]; // range operator to convert the List to an array
    }
}
