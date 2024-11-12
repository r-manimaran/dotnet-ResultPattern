namespace dotnet_ResultPattern;

public static class MovieErrors
{
    public static readonly Error TitleInvalid = new Error("Movie.TitleInvalid", "Title is invalid");
    public static readonly Error GenreInvalid = new Error("Movie.GenreInvalid", "Genre is invalid");
    public static readonly Error YearInvalid = new Error("Movie.YearInvalid", "Year is invalid");
}
