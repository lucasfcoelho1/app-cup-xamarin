using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCupApp.Models
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
        
        /*
         * if the api is updated just add the link 
         * of the movie cover in the list
         */
        public string UrlPhoto { get; set; }
        #endregion
    }
}
