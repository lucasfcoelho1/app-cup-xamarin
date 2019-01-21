using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCupApi.Models
{
    public class Match
    {
        #region props
        public Movie Movie1 { get; private set; }
        public Movie Movie2 { get; private set; } 
        #endregion

        public Match(Movie movie1, Movie movie2)
        {
            Movie1 = movie1;
            Movie2 = movie2;
        }

        /*
         * 
         * the following methods are returning tuples to get the winner and the loser of each match
         * 
         */

        #region methods
        internal (Movie winner, Movie loser) GetResult()
        {
            return Movie1.Rating != Movie2.Rating ? GetWinnerByRating() : GetWinnerByAscendingOrder();
        }

        private (Movie winner, Movie loser) GetWinnerByRating()
        {
            if (Movie1.Rating > Movie2.Rating)
                return (Movie1, Movie2);
            else
                return (Movie2, Movie1);
        }

        private (Movie winner, Movie loser) GetWinnerByAscendingOrder()
        {
            if (string.Compare(Movie1.Title, Movie2.Title) < 0)
                return (Movie1, Movie2);

            else
                return (Movie2, Movie1);
        } 
        #endregion

    }
}