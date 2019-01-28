using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCupApp.Utils
{
    public static class ApiSync
    {
        public static async Task<T> GetAsync<T>(string url, string method) where T : class
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{url}{method}");
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public static async Task<T> Post<T>(string[] moviesId, string url, string method) where T : class
        {
            var json = JsonConvert.SerializeObject(moviesId);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{url}{method}", content);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
                return null;
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            if (typeof(T) == typeof(string))
                return jsonResult as T;
            var rootobject = JsonConvert.DeserializeObject<T>(jsonResult);
            return rootobject;
        }
    }
}
