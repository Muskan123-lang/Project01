using Microsoft.AspNetCore.Mvc;
using Nagarro.BookTheShow.Interfaces.Service;
using Nagarro.BookTheShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nagarro.BookTheShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieDetailController(IMovieService userService)
        {
            _movieService = userService;

        }

        // GET: api/<MovieDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<MovieDetail>> GetAllMovie()
        {
            return _movieService.GetAllMovie().Select(x => new MovieDetail { Id = x.Id, MovieName=x.MovieName,MovieDescription=x.MovieDescription,MovieImage=x.MovieImage,IsActive=x.IsActive}).ToList();
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<MovieDetail> GetMovie(int id)
        {
            var movie = _movieService.GetMovie(id);
            if (movie == null)
                return NotFound();
            var movieDetails = new MovieDetail { Id = movie.Id, MovieName=movie.MovieName,MovieDescription=movie.MovieDescription,MovieImage=movie.MovieImage,IsActive=movie.IsActive};
            return movieDetails;
        }

        // POST api/<MovieDetailController>
        [HttpPost]
        public ActionResult CreateMovie([FromBody] MovieDetail movieDetails)
        {
            var movie = new Interfaces.Domain.Movie();
            movie.MovieName = movieDetails.MovieName;
            movie.MovieDescription = movieDetails.MovieDescription;
            movie.MovieImage = movieDetails.MovieImage;
            movie.IsActive = movieDetails.IsActive;
            _movieService.CreateMovie(movie);
            return Ok();
        }

        // PUT api/<MovieDetailController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, [FromBody] MovieDetail movieDetails)
        {
            var movie = _movieService.GetMovie(id);
            if (movie == null)
                return NotFound();
            movie.MovieName = movieDetails.MovieName;
            movie.MovieDescription = movieDetails.MovieDescription;
            movie.MovieImage = movieDetails.MovieImage;
            movie.IsActive = movieDetails.IsActive;
            _movieService.UpdateMovie(id, movie);
            return Ok();
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movie = _movieService.GetMovie(id);
            if (movie == null)
                return NotFound();
            _movieService.DeleteMovie(id);
            return Ok();
        }
    }
}
