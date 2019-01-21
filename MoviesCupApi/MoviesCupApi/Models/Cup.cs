using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Models
{
    public class Cup
    {
        #region props
        public Movie FirstPlace { get; private set; }
        public Movie SecondPlace { get; private set; } 
        #endregion

        public Cup(List<Movie> movies)
        {
            StartMatches(movies);
        }

        #region methods

        internal void StartMatches(List<Movie> movies)
        {
            var winners = new List<Movie>();
            var matches = new List<Match>();

            //positioning movies to the match
            while (movies.Count > 0)
            {
                matches.Add(new Match(movies.FirstOrDefault(), movies.LastOrDefault()));
                movies.Remove(movies.FirstOrDefault());
                movies.Remove(movies.LastOrDefault());
            }

            //handle the final match
            if (matches.Count == 1)
            {
                var finalMatch = matches.FirstOrDefault().GetResult();
                FirstPlace = finalMatch.winner;
                SecondPlace = finalMatch.loser;
                return;
            }

            //getting the result of the match
            while (matches.Count > 0)
            {
                winners.Add(matches.FirstOrDefault().GetResult().winner);
                matches.Remove(matches.FirstOrDefault());
            }

            //calling  the same method recursively until the final match
            StartMatches(winners);
        } 
        #endregion
    }
}
