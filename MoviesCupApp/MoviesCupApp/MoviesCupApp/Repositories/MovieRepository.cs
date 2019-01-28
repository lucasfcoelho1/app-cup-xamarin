using MoviesCupApp.Models;
using MoviesCupApp.Repositories.Interfaces;
using MoviesCupApp.Resources;
using MoviesCupApp.Utils;
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
        private const string API_URL = "https://movies-cup.azurewebsites.net/api/";

        public async Task<T> GetMoviesAsync<T>() where T : class
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert(null, AppResources.InternetProblems, AppResources.OK);
                return null;
            }
            try
            {
                return await ApiSync.GetAsync<T>(API_URL, "movies/getall");
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
                return await ApiSync.Post<T>(moviesId, API_URL, "cup/startcup");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        
    }
}
