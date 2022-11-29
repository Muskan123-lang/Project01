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
    public class MovieListingController : ControllerBase
    {
        private readonly IMovieListingService _movieslotService;

        public MovieListingController(IMovieListingService movieslotService)
        {
            _movieslotService = movieslotService;
        }

        // GET: api/<MovieListingController>
        [HttpGet]
        public ActionResult<IEnumerable<MovieListing>> GetAllMovieListing()
        {
            return _movieslotService.GetAllMovieListing().Select(x => new MovieListing { Id = x.Id, MovieName = x.MovieName, MovieDescription = x.MovieDescription, MovieImage = x.MovieImage, MovieTime = x.MovieTime, MovieDate = x.MovieDate, Fare = x.Fare, MaxSeats = x.MaxSeats, AvailableSeats = x.AvailableSeats }).ToList();
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<MovieListing> GetMovieListing(int id)
        {
            var movieslot = _movieslotService.GetMovieListing(id);
            if (movieslot == null)
                return NotFound();
            var movieslotDetails = new MovieListing { Id = movieslot.Id, MovieName=movieslot.MovieName,MovieDescription=movieslot.MovieDescription,MovieImage=movieslot.MovieImage,MovieTime = movieslot.MovieTime, Fare = movieslot.Fare, MovieDate = movieslot.MovieDate, MaxSeats = movieslot.MaxSeats, AvailableSeats = movieslot.AvailableSeats };
            return movieslotDetails;
        }

        // POST api/<MovieDetailController>
        [HttpPost]
        public ActionResult CreateMovieListing([FromBody] MovieListing movieslotDetails)
        {
            var movieslot = new Interfaces.Domain.MovieListing();
            movieslot.MovieName = movieslotDetails.MovieName;
            movieslot.MovieDescription = movieslotDetails.MovieDescription;
            movieslot.MovieImage = movieslotDetails.MovieImage;
            movieslot.MovieTime = movieslotDetails.MovieTime;
            movieslot.Fare = movieslotDetails.Fare;
            movieslot.MovieDate = movieslotDetails.MovieDate;
            movieslot.MaxSeats = movieslotDetails.MaxSeats;
            movieslot.AvailableSeats = movieslotDetails.AvailableSeats;
            _movieslotService.CreateMovieListing(movieslot);
            return Ok();
        }

        // PUT api/<MovieDetailController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMovieListing(int id, [FromBody] MovieListing movieslotDetails)
        {
            var movieslot = _movieslotService.GetMovieListing(id);
            if (movieslot == null)
                return NotFound();
            movieslot.MovieName = movieslotDetails.MovieName;
            movieslot.MovieDescription = movieslotDetails.MovieDescription;
            movieslot.MovieImage = movieslotDetails.MovieImage;
            movieslot.MovieTime = movieslotDetails.MovieTime;
            movieslot.Fare = movieslotDetails.Fare;
            movieslot.MovieDate = movieslotDetails.MovieDate;
            movieslot.MaxSeats = movieslotDetails.MaxSeats;
            movieslot.AvailableSeats = movieslotDetails.AvailableSeats;
            _movieslotService.UpdateMovieListing(id, movieslot);
            return Ok();
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMovieListing(int id)
        {
            var movieslot = _movieslotService.GetMovieListing(id);
            if (movieslot == null)
                return NotFound();
            _movieslotService.DeleteMovieListing(id);
            return Ok();
        }
    }
}
