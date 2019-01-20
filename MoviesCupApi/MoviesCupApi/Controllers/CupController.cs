using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using MoviesCupApi.Services.Interfaces;

namespace MoviesCupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupController : ControllerBase
    {
        IMovieRepository _movieRepository;
        ICupService _cupService;
        public CupController(IMovieRepository movieRepository, ICupService cupService)
        {
            _movieRepository = movieRepository;
            _cupService = cupService;
        }

        [HttpPost]
        public async Task<IActionResult> StartCup([FromBody]List<string> moviesIdentifiers)
        {
            if (moviesIdentifiers == null || moviesIdentifiers.Count < 1)
                return BadRequest("Identifiers is empty");
            if (moviesIdentifiers.Count != 8)
                return BadRequest("Wrong movies list size");
            try
            {
                List<Movie> movies = null;
                movies = await _movieRepository.GetAllMoviesAsync();
                if (movies == null || movies.Count < 1)
                    return BadRequest("Movies list is empty");

                var cupResult = _cupService.StartCup(moviesIdentifiers, movies);
                return Ok(cupResult);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}