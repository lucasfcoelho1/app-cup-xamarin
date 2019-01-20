using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Models
{
    public class Cup
    {
        public List<Movie> Movies { get; set; }

        public Cup(List<Movie> movies)
        {
            Movies = movies;
        }
    }
}
