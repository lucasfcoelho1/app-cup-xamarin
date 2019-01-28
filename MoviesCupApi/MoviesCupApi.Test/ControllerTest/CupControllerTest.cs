using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesCupApi.Controllers;
using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using MoviesCupApi.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesCupApi.Test.ControllerTest
{
    public class CupControllerTest
    {
        Mock<IMovieRepository> _movieRepository;
        Mock<ICupService> _cupService;
        private CupController Controller { get; set; }
        private string[] moviesIdentifiers;

        public CupControllerTest()
        {
            moviesIdentifiers = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };
            _movieRepository = new Mock<IMovieRepository>();
            _cupService = new Mock<ICupService>();
            Controller = new CupController(_movieRepository.Object, _cupService.Object);
        }
        [Fact]
        public async Task TestStartCupIdentifierNullStatusCode500()
        {
            //arrange
            moviesIdentifiers = null;
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Identifiers cannot be null", (actionResult as ObjectResult).Value);
        }

        [Fact]
        public async Task TestStartCupIdentifiersLessThan8()
        {
            //arrange
            //7 element
            moviesIdentifiers = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644" };
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Identifier list must have 8 elements", (actionResult as ObjectResult).Value);
        }

        [Fact]
        public async Task TestStartCupIdentifiersGreaterThan8()
        {
            //arrange
            //9 elements
            moviesIdentifiers = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632", "tt3501632" };
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Identifier list must have 8 elements", (actionResult as ObjectResult).Value);
        }

        [Fact]
        public async Task TestGetAllAsStringOkResult()
        {
            //arrange
            var list = UtilsTest.UtilsTest.GetMoviesList();
            var jsonCupResult = "{\"FirstPlace\":{\"id\":\"tt4154756\",\"titulo\":\"Vingadores: Guerra Infinita\",\"ano\":2018,\"nota\":8.8},\"SecondPlace\":{\"id\":\"tt3606756\",\"titulo\":\"Os Incríveis 2\",\"ano\":2018,\"nota\":8.5}}";

            _movieRepository.Setup(x => x.GetAllMoviesAsync(false))
                .Returns(UtilsTest.UtilsTest.GetReturnHelper(null, list));

            _cupService.Setup(x => x.StartCup(new List<string>(moviesIdentifiers), list))
                .Returns(jsonCupResult);
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(jsonCupResult, (actionResult as OkObjectResult).Value);
        }

        [Fact]
        public async Task TestGetAllAsStringJsonResultNull()
        {
            //arrange
            var list = UtilsTest.UtilsTest.GetMoviesList();
            string jsonCupResult = null;

            _movieRepository.Setup(x => x.GetAllMoviesAsync(false))
                .Returns(UtilsTest.UtilsTest.GetReturnHelper(null, list));

            _cupService.Setup(x => x.StartCup(new List<string>(moviesIdentifiers), list))
                .Returns(jsonCupResult);
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Cup result is null", (actionResult as ObjectResult).Value);
        }

        [Fact]
        public async Task TestGetAllAsStringMoviesListNull()
        {
            //arrange
            var list = UtilsTest.UtilsTest.GetMoviesList();
            string jsonCupResult = null;

            _movieRepository.Setup(x => x.GetAllMoviesAsync(true))
                .Returns(UtilsTest.UtilsTest.GetReturnHelper(null, null));

            _cupService.Setup(x => x.StartCup(new List<string>(moviesIdentifiers), list))
                .Returns(jsonCupResult);
            //act
            var actionResult = await Controller.StartCup(moviesIdentifiers);
            //assert
            Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Movies list is empty", (actionResult as ObjectResult).Value);
        }
    }
}
