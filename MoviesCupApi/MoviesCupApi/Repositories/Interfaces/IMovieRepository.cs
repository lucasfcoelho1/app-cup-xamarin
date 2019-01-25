using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<(string json, List<Movie> moviesList)> GetAllMoviesAsync(bool returnAsJson);
    }
}
