using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Services.Interfaces
{
    public interface ICupService
    {
        Cup StartCup(List<string> moviesIdentifiers, List<Movie> movies);
    }
}
