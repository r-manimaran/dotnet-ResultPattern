namespace dotnet_ResultPattern;
using FluentValidation;
using dotnet_ResultPattern.Models;

public class MovieValidator:AbstractValidator<Movie>
{
    // Validation Rules for Movie
    public MovieValidator()
    {
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x=>x.Year).NotEmpty().WithMessage("Year is required");
        // RuleFor(x=>x.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Year must be between 1900 and current year");
        RuleFor(x=>x.Genre).NotEmpty().WithMessage("Genres is required");        
    }
}
