using MoviesCupApi.Models;
using MoviesCupApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MoviesCupApi.Test.ServicesTest
{
    public class CupServiceTest
    {
        private string[] identifiers = { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };
        private string jsonCupResult = "{\"FirstPlace\":{\"id\":\"tt4154756\",\"titulo\":\"Vingadores: Guerra Infinita\",\"ano\":2018,\"nota\":8.8},\"SecondPlace\":{\"id\":\"tt3606756\",\"titulo\":\"Os Incríveis 2\",\"ano\":2018,\"nota\":8.5}}";

        [Fact]
        public void TestStartCup()
        {
            var jsonResult = new CupService().StartCup(new List<string>(identifiers), UtilsTest.UtilsTest.GetMoviesList());
            Assert.Equal(jsonCupResult, jsonResult);
        }
    }
}
