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

        [HttpPost("StartCup")]
        public async Task<IActionResult> StartCup([FromBody]string[] moviesIdentifiers)
        {
            var identifier = new List<string>(moviesIdentifiers);
            if (identifier == null || identifier.Count < 1)
                return StatusCode(500);
            if (identifier.Count != 8)
                return StatusCode(500);
            try
            {
                var result = await _movieRepository.GetAllMoviesAsync(returnAsJson: false);
                if (result.moviesList.Count < 1)
                    return StatusCode(500);

                var cupResult = _cupService.StartCup(identifier, result.moviesList);
                if (string.IsNullOrEmpty(cupResult))
                    return StatusCode(500);
                return Ok(cupResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}