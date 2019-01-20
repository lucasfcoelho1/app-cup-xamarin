using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Exceptions
{
    public class MoviesListSizeException : Exception
    {
        public MoviesListSizeException(string message) : base(message)
        {
        }

        public MoviesListSizeException() : base("Invalid list, check the number of movies")
        {
        }
    }
}
