using System;
using System.Collections.Generic;
using System.Linq;
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

        //return all movies
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            try
            {
                var movies = await _movieRepository.GetAllMoviesAsync();
                return Ok(movies);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //api hello world
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "api is working";
        }
    }
}