using MoviesCupApi.Models;
using MoviesCupApi.Services.Interfaces;
using MoviesCupApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Services
{
    public class CupService : ICupService
    {
        public Cup StartCup(List<string> moviesIdentifiers, List<Movie> movies)
        {
            movies = movies.FindAll(m => moviesIdentifiers.Any(x => x == m.Identifier));
            movies = SortMovies.Sort(movies);
            return new Cup(movies);
        }
    }
}
