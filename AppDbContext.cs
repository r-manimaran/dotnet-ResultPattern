namespace dotnet_ResultPattern;

using Microsoft.EntityFrameworkCore;
using dotnet_ResultPattern.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Movie> Movies {get; set;}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //  optionsBuilder.UseSqlite("Data Source=movies.db");
    }

    /// <summary>
    ///  Add Some Sample Data.
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder.</param>
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Matrix", Year = new DateTime(1999, 3, 31), Genre= "Action" },
            new Movie { Id = 2, Title = "The Matrix Reloaded", Year = new DateTime(2003, 5, 15), Genre="Action" },
            new Movie { Id = 3, Title = "The Matrix Revolutions", Year = new DateTime(2003, 11, 5), Genre="Action" },
            new Movie { Id = 4, Title = "The Matrix Resurrections", Year = new DateTime(2021, 12, 22), Genre="Action" }
        );
    }
}
