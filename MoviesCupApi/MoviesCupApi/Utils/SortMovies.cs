using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Utils
{
    public static class SortMovies
    {
        public static List<Movie> Sort(List<Movie> moviesList) => 
            moviesList.OrderBy(m => m.Title).ToList();
    }
}
