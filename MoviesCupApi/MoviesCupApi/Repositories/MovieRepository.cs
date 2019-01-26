using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using MoviesCupApi.Utils;
using MoviesCupApi.Utils.Interfaces;
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
        private readonly IHttpHandler _httpHandler;
        public MovieRepository(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        //return all movies from copafilmes api
        /*
         * this method return either a pure string json, or a deserialized list of movies,
         * it depends of the bool parameter 'returnAsJson'
         */
        public async Task<(string json, List<Movie> moviesList)> GetAllMoviesAsync(bool returnAsJson)
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync(URL_API);
                if (responseMessage.IsSuccessStatusCode)
                {
                    if (returnAsJson)
                        return (await responseMessage.Content.ReadAsStringAsync(), null);
                    else
                        return (null, JsonConvert.DeserializeObject<List<Movie>>(await responseMessage.Content.ReadAsStringAsync()));
                }
                else
                    return (null, null);
            }
        }
    }
}
