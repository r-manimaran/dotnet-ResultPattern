namespace dotnet_ResultPattern.Exceptions;

internal class MovieValidationException : BadRequestException
{
    public MovieValidationException(Error[] errors) : base("Movie validation failed",errors)
    {
        
    }
}