using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> StartCup([Required][FromBody]string[] moviesIdentifiers)
        {
            if (moviesIdentifiers == null || moviesIdentifiers.Length < 1)
                return StatusCode(500, "Identifiers cannot be null");
            var identifiersList = new List<string>(moviesIdentifiers);
            if (identifiersList.Count != 8)
                return StatusCode(500, "Identifier list must have 8 elements");
            try
            {
                var result = await _movieRepository.GetAllMoviesAsync(returnAsJson: false);
                if (result.moviesList == null || result.moviesList?.Count < 1)
                    return StatusCode(500, "Movies list is empty");

                var cupResult = _cupService.StartCup(identifiersList, result.moviesList);
                if (string.IsNullOrEmpty(cupResult))
                    return StatusCode(500, "Cup result is null");
                return Ok(cupResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}