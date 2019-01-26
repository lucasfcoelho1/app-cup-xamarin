using MoviesCupApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCupApp.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<T> GetMoviesAsync<T>() where T : class;
        Task<T> PostAsync<T>(string[] moviesId) where T : class;
    }
}
