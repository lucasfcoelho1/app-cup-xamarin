using MoviesCupApi.Models;
using MoviesCupApi.Services.Interfaces;
using MoviesCupApi.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCupApi.Services
{
    public class CupService : ICupService
    {
        public string StartCup(List<string> moviesIdentifiers, List<Movie> movies)
        {
            movies = movies.FindAll(m => moviesIdentifiers.Any(x => x == m.Identifier));
            if (movies == null || movies.Count < 1)
                return null;

            movies = SortMovies.Sort(movies);
            var cup = new Cup(movies);
            return JsonConvert.SerializeObject(cup);
        }
    }
}
