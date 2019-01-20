using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesCupApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string URL_API = "http://copadosfilmes.azurewebsites.net/api/filmes";

        //return all movies from copafilmes api
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var movies = new List<Movie>();
                var responseMessage = await httpClient.GetAsync(URL_API);
                if (responseMessage.IsSuccessStatusCode)
                    movies = JsonConvert.DeserializeObject<List<Movie>>(await responseMessage.Content.ReadAsStringAsync());
                return movies;
            }
        }
    }
}
