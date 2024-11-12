using dotnet_ResultPattern.Exceptions;

namespace dotnet_ResultPattern;

public class MovieAlreadyExistsException : BadRequestException
{
    public MovieAlreadyExistsException(string Moviename) : base($"Movie with name {Moviename} already exists")
    {
        
    }
}
