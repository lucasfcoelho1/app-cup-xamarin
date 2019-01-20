using MoviesCupApi.Exceptions;
using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Utils
{
    public static class ValidateListSize
    {
        public static void ValidateMovieListSize(List<Movie> movies)
        {
            if(movies.Count > 8 || movies.Count < 8 || movies == null)
                throw new MoviesListSizeException();
        }
    }
}
