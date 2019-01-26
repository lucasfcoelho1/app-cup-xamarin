using MoviesCupApp.Models;
using MoviesCupApp.Repositories.Interfaces;
using MoviesCupApp.Resources;
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

        public async Task<T> GetMoviesAsync<T>() where T : class
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert(null, AppResources.InternetProblems, AppResources.OK);
                return null;
            }
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{API_URL}/movies/getall");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(AppResources.Oops, e.Message, AppResources.OK);
                Debug.WriteLine(e.Message, "Error on refresh");
            }
            return null;
        }

        public async Task<T> PostAsync<T>(string[] moviesId) where T : class
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert(null, AppResources.InternetProblems, AppResources.OK);
                return null;
            }
            try
            {
                var json = JsonConvert.SerializeObject(moviesId);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync($"{API_URL}/cup/startcup", content);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
                    return null;
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                if (typeof(T) == typeof(string))
                    return jsonResult as T;
                var rootobject = JsonConvert.DeserializeObject<T>(jsonResult);
                return rootobject;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
