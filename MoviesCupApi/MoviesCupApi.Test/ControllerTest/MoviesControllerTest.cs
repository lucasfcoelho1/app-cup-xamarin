using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesCupApi.Controllers;
using MoviesCupApi.Models;
using MoviesCupApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MoviesCupApi.Test.ControllerTest
{
    public class MoviesControllerTest
    {
        Mock<IMovieRepository> _movieRepository;
        public MoviesController Controller { get; set; }
        public MoviesControllerTest()
        {
            _movieRepository = new Mock<IMovieRepository>();
            Controller = new MoviesController(_movieRepository.Object);
        }

        [Fact]
        public async Task TestGetAllAsStringOkResult()
        {
            _movieRepository.Setup(x => x.GetAllMoviesAsync(true))
                .Returns(UtilsTest.UtilsTest.GetReturnHelper(UtilsTest.UtilsTest.arrayList, null));
            var actionResult = await Controller.GetAllMoviesAsync();
            Assert.IsType<OkObjectResult>(actionResult);
            
            Assert.Equal(UtilsTest.UtilsTest.arrayList, (actionResult as OkObjectResult).Value);
        }

        [Fact]
        public async Task TestGetAllAsListStatuscode500Result()
        {
            _movieRepository.Setup(x => x.GetAllMoviesAsync(false))
                .Returns(UtilsTest.UtilsTest.GetReturnHelper(null, UtilsTest.UtilsTest.GetMoviesList()));
            var actionResult = await Controller.GetAllMoviesAsync();
            Assert.IsType<ObjectResult>(actionResult);
            
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            Assert.Equal("Movies list is null", (actionResult as ObjectResult).Value);

        }

        [Fact]
        public void TestSimpleGet()
        {
            var actionResult = Controller.Get();
            Assert.Equal("Api v1 is working", actionResult.Value);
        }
    }
}
