using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesCupApi.Repositories.Interfaces;

namespace MoviesCupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            try
            {
                var result = await _movieRepository.GetAllMoviesAsync(returnAsJson: true);
                if (result.json == null)
                    return StatusCode(500, "Movies list is null");
                return Ok(result.json);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}