using MoviesCupApp.Models;
using MoviesCupApp.Repositories.Interfaces;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCupApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private const string API_URL = "https://movies-cup.azurewebsites.net/api";
        //private const string API_URL = "http://192.168.0.106:56430/api";
        //private const string API_URL = "http://192.168.0.106:63476/api";

        public async Task<List<Movie>> GetMovies()
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert(null, "Problemas com a internet", "OK");
                return null;
            }
            try
            {
                var client = new HttpClient();
                var s = $"{API_URL}/movies/getall";
                var response = await client.GetAsync(s);
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Movie>>(jsonResult);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Oops...", "Algo deu errado na atualização dos dados", "OK");
                Debug.WriteLine(e.Message, "Error on refresh");
            }
            return null;
        }

    }
}
