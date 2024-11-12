using Microsoft.EntityFrameworkCore;
using dotnet_ResultPattern;
using dotnet_ResultPattern.Services;
using dotnet_ResultPattern.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite("Data Source=movies.db");
});

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(_ => { });

app.Run();
