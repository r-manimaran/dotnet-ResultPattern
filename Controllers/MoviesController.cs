using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ResultPattern.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovies(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
        {
            var movie = await _movieService.CreateMovieAsync(request);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
    }

