using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using MoviesCupApi.Utils;

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
                    return BadRequest("List is empty");
                return Ok(result.json);
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
            return "Api v1 is working";
        }
    }
}