﻿using System;
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
                return BadRequest("Identifiers is empty");
            if (identifier.Count != 8)
                return BadRequest("Wrong movies list size");
            try
            {
                List<Movie> movies = null;
                movies = await _movieRepository.GetAllMoviesAsync();
                if (movies == null || movies.Count < 1)
                    return BadRequest("Movies list is empty");

                var cupResult = _cupService.StartCup(identifier, movies);
                if (cupResult == null)
                    return BadRequest("Problems in creating the cup");
                return Ok(cupResult);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}