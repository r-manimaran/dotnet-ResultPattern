using Microsoft.AspNetCore.Http.HttpResults;

namespace dotnet_ResultPattern.Exceptions;
public class NotFoundException : BadRequestException
{
    public NotFoundException(string message) : base(message)
    {

    }
}