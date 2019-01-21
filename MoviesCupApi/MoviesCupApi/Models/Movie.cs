using Newtonsoft.Json;

namespace MoviesCupApi.Models
{
    public class Movie
    {
        #region props
        [JsonProperty("id")]
        public string Identifier { get; set; }
        [JsonProperty("titulo")]
        public string Title { get; set; }
        [JsonProperty("ano")]
        public int Year { get; set; }
        [JsonProperty("nota")]
        public double Rating { get; set; } 
        #endregion
    }
}