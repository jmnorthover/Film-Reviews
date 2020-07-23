using Microsoft.AspNetCore.Mvc;
using RestAPI.Domain.Services;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("/api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetMovieDetailsAsync([FromRoute] int movieId)
        {
            var result = await _movieService.GetMovieDetailsAsync(movieId);

            if (result.Success)
            {
                return Ok(result.Details);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("search/{query}")]
        public async Task<IActionResult> MovieSearchAsync([FromRoute] string query)
        {
            var result = await _movieService.SearchMoviesAsync(query);

            if (result.Success)
            {
                return Ok(result.Results);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
    }
}