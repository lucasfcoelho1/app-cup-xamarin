using MoviesCupApi.Models;
using MoviesCupApi.Services.Interfaces;
using MoviesCupApi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Services
{
    public class CupService : ICupService
    {
        public string StartCup(List<string> moviesIdentifiers, List<Movie> movies)
        {
            movies = movies.FindAll(m => moviesIdentifiers.Any(x => x == m.Identifier));
            movies = SortMovies.Sort(movies);
            var cup = new Cup(movies);
            return JsonConvert.SerializeObject(cup);
        }
    }
}
