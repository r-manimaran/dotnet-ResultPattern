namespace dotnet_ResultPattern.Exceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message,Error[]? errors =null) : base(message)
    {
        errors = errors?? [];
    }
    public Error[] Errors { get; }
}