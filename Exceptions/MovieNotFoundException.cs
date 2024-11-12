namespace dotnet_ResultPattern.Exceptions;

public class MovieNotFoundException : NotFoundException
{
    public MovieNotFoundException(int movieId) : base($"Movie with id {movieId} not found")
    {
        
    }   
}