using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MoviesCupApi.Test.ModelsTest
{
    public class MatchTest
    {
        [Fact]
        public void GetWinnerByRatingTest()
        {
            var movie1 = new Movie { Identifier = "tt4154756", Title = "Vingadores: Guerra Infinita", Year = 2018, Rating = 8.8 };
            var movie2 = new Movie { Identifier = "tt3606756", Title = "Os Incríveis 2", Year = 2018, Rating = 8.5 };
            var match = new Match(movie1, movie2);

            var result = match.GetWinnerByRating();

            Assert.Equal("Vingadores: Guerra Infinita", result.winner.Title);
        }

        [Fact]
        public void GetWinnerByAscendingTest()
        {
            var movie1 = new Movie { Identifier = "tt6499752", Title = "Upgrade", Year = 2018, Rating = 7.8 };
            var movie2 = new Movie { Identifier = "tt7784604", Title = "Hereditário", Year = 2018, Rating = 7.8 };
            var match = new Match(movie1, movie2);

            var result = match.GetWinnerByAscendingOrder();

            Assert.Equal("Hereditário", result.winner.Title);
        }

        [Fact]
        public void GetResultsTest()
        {
            var movie1 = new Movie { Identifier = "tt4154756", Title = "Vingadores: Guerra Infinita", Year = 2018, Rating = 8.8 };
            var movie2 = new Movie { Identifier = "tt3606756", Title = "Os Incríveis 2", Year = 2018, Rating = 8.5 };
            var match = new Match(movie1, movie2);

            var result = match.GetResult();
            Assert.Equal("Vingadores: Guerra Infinita", result.winner.Title);

            movie1 = new Movie { Identifier = "tt6499752", Title = "Upgrade", Year = 2018, Rating = 7.8 };
            movie2 = new Movie { Identifier = "tt7784604", Title = "Hereditário", Year = 2018, Rating = 7.8 };
            match = new Match(movie1, movie2);

            result = match.GetResult();
            Assert.Equal("Hereditário", result.winner.Title);
        }
    }
}
