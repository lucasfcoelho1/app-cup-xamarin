using MoviesCupApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCupApi.Test.UtilsTest
{
    public static class UtilsTest
    {
        public const string arrayList = "[{\"id\":\"tt3606756\",\"titulo\":\"Os Incríveis 2\",\"ano\":2018,\"nota\":8.5},{\"id\":\"tt4881806\",\"titulo\":\"Jurassic World: Reino Ameaçado\",\"ano\":2018,\"nota\":6.7},{\"id\":\"tt5164214\",\"titulo\":\"Oito Mulheres e um Segredo\",\"ano\":2018,\"nota\":6.3},{\"id\":\"tt7784604\",\"titulo\":\"Hereditário\",\"ano\":2018,\"nota\":7.8},{\"id\":\"tt4154756\",\"titulo\":\"Vingadores: Guerra Infinita\",\"ano\":2018,\"nota\":8.8},{\"id\":\"tt5463162\",\"titulo\":\"Deadpool 2\",\"ano\":2018,\"nota\":8.1},{\"id\":\"tt3778644\",\"titulo\":\"Han Solo: Uma História Star Wars\",\"ano\":2018,\"nota\":7.2},{\"id\":\"tt3501632\",\"titulo\":\"Thor: Ragnarok\",\"ano\":2017,\"nota\":7.9},{\"id\":\"tt2854926\",\"titulo\":\"Te Peguei!\",\"ano\":2018,\"nota\":7.1},{\"id\":\"tt0317705\",\"titulo\":\"Os Incríveis\",\"ano\":2004,\"nota\":8.0},{\"id\":\"tt3799232\",\"titulo\":\"A Barraca do Beijo\",\"ano\":2018,\"nota\":6.4},{\"id\":\"tt1365519\",\"titulo\":\"Tomb Raider: A Origem\",\"ano\":2018,\"nota\":6.5},{\"id\":\"tt1825683\",\"titulo\":\"Pantera Negra\",\"ano\":2018,\"nota\":7.5},{\"id\":\"tt5834262\",\"titulo\":\"Hotel Artemis\",\"ano\":2018,\"nota\":6.3},{\"id\":\"tt7690670\",\"titulo\":\"Superfly\",\"ano\":2018,\"nota\":5.1},{\"id\":\"tt6499752\",\"titulo\":\"Upgrade\",\"ano\":2018,\"nota\":7.8}]";
        internal static async Task<(string json, List<Movie> moviesList)> GetReturnHelper(string json, List<Movie> moviesList) =>
            (json, moviesList);

        internal static List<Movie> GetMoviesList()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Identifier = "tt3606756",
                    Title = "Os Incríveis 2",
                    Year = 2018,
                    Rating = 8.5
                },
                new Movie
                {
                    Identifier = "tt4881806",
                    Title = "Jurassic World: Reino Ameaçado",
                    Year = 2018,
                    Rating = 6.7
                },
                new Movie
                {
                    Identifier = "tt5164214",
                    Title = "Oito Mulheres e um Segredo",
                    Year = 2018,
                    Rating = 6.3
                },
                new Movie
                {
                    Identifier = "tt7784604",
                    Title = "Hereditário",
                    Year = 2018,
                    Rating = 7.8
                },
                new Movie
                {
                    Identifier = "tt4154756",
                    Title = "Vingadores: Guerra Infinita",
                    Year = 2018,
                    Rating = 8.8
                },
                new Movie
                {
                    Identifier = "tt5463162",
                    Title = "Deadpool 2",
                    Year = 2018,
                    Rating = 8.1
                },
                new Movie
                {
                    Identifier = "tt3778644",
                    Title = "Han Solo: Uma História Star Wars",
                    Year = 2018,
                    Rating = 7.2
                },
                new Movie
                {
                    Identifier = "tt3501632",
                    Title = "Thor: Ragnarok",
                    Year = 2017,
                    Rating = 7.9
                },
                new Movie
                {
                    Identifier = "tt2854926",
                    Title = "Te Peguei!",
                    Year = 2018,
                    Rating = 7.1
                },
                new Movie
                {
                    Identifier = "tt0317705",
                    Title = "Os Incríveis",
                    Year = 2004,
                    Rating = 8.0
                },
                new Movie
                {
                    Identifier = "tt3799232",
                    Title = "A Barraca do Beijo",
                    Year = 2018,
                    Rating = 6.4
                },
                new Movie
                {
                    Identifier = "tt1365519",
                    Title = "Tomb Raider: A Origem",
                    Year = 2018,
                    Rating = 6.5
                },
                new Movie
                {
                    Identifier = "tt1825683",
                    Title = "Pantera Negra",
                    Year = 2018,
                    Rating = 7.5
                },
                new Movie
                {
                    Identifier = "tt5834262",
                    Title = "Hotel Artemis",
                    Year = 2018,
                    Rating = 6.3
                },
                new Movie
                {
                    Identifier = "tt7690670",
                    Title = "Superfly",
                    Year = 2018,
                    Rating = 5.1
                },
                new Movie
                {
                    Identifier = "tt6499752",
                    Title = "Upgrade",
                    Year = 2018,
                    Rating = 7.8
                },

            };
        }

    }
}
