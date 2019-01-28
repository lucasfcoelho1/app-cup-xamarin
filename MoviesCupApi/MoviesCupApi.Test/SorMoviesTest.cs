using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MoviesCupApi.Test
{
    public class SorMoviesTest
    {
        [Fact]
        public void TestSortListAscendingByTitle()
        {
            var sortedList = Utils.SortMovies.Sort(UtilsTest.UtilsTest.GetMoviesList());
            //first
            Assert.Equal("A Barraca do Beijo", sortedList[0].Title);
            //last
            Assert.Equal("Vingadores: Guerra Infinita", sortedList[15].Title);
        }
    }
}
