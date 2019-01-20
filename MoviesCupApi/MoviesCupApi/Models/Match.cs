using System;

namespace MoviesCupApi.Models
{
    public class Match
    {
        public Movie Movie1 { get; set; }
        public Movie Movie2 { get; set; }

        public Match(Movie movie1, Movie movie2)
        {
            Movie1 = movie1;
            Movie2 = movie2;
        }

        public Movie GetWinner() => Movie1.Rating == Movie2.Rating ? GetWinnerByAscendingOrder() : GetWinnerByRating();

        private Movie GetWinnerByRating() => Movie1.Rating > Movie2.Rating ? Movie1 : Movie2;

        public Movie GetWinnerByAscendingOrder() => string.Compare(Movie1.Title, Movie2.Title) < 0 ? Movie1 : Movie2;
    }
}