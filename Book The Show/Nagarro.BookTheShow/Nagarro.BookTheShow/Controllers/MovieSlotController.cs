using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nagarro.BookTheShow.Interfaces.Service;
using Nagarro.BookTheShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSlotController : ControllerBase
    {
        private readonly IMovieSlotService _movieslotService;

        public MovieSlotController(IMovieSlotService movieslotService)
        {
            _movieslotService = movieslotService;
        }

        

        [HttpGet]
        public ActionResult<IEnumerable<MovieSlotDetail>> GetAllMovieSlot()
        {
            return _movieslotService.GetAllMovieSlot().Select(x => new MovieSlotDetail { Id = x.Id, MovieId=x.MovieId,MovieTime=x.MovieTime,MovieDate=x.MovieDate,Fare=x.Fare,MaxSeats=x.MaxSeats,AvailableSeats=x.AvailableSeats}).ToList();
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<MovieSlotDetail> GetMovieSlot(int id)
        {
            var movieslot = _movieslotService.GetMovieSlot(id);
            if (movieslot == null)
                return NotFound();
            var movieslotDetails = new MovieSlotDetail { Id = movieslot.Id,MovieId=movieslot.MovieId,MovieTime = movieslot.MovieTime, Fare = movieslot.Fare, MovieDate = movieslot.MovieDate,MaxSeats=movieslot.MaxSeats,AvailableSeats=movieslot.AvailableSeats};
            return movieslotDetails;
        }

        // POST api/<MovieDetailController>
        [HttpPost]
        public ActionResult CreateMovieSlot([FromBody] MovieSlotDetail movieslotDetails)
        {
            var movieslot = new Interfaces.Domain.MovieSlot();
            movieslot.MovieId = movieslotDetails.MovieId;
            movieslot.MovieTime = movieslotDetails.MovieTime;
            movieslot.Fare = movieslotDetails.Fare;
            movieslot.MovieDate = movieslotDetails.MovieDate;
            movieslot.MaxSeats = movieslotDetails.MaxSeats;
            movieslot.AvailableSeats = movieslotDetails.AvailableSeats;
            _movieslotService.CreateMovieSlot(movieslot);
            return Ok();
        }

        // PUT api/<MovieDetailController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMovieSlot(int id, [FromBody] MovieSlotDetail movieslotDetails)
        {
            var movieslot = _movieslotService.GetMovieSlot(id);
            if (movieslot == null)
                return NotFound();
            movieslot.MovieId = movieslotDetails.MovieId;
            movieslot.MovieTime = movieslotDetails.MovieTime;
            movieslot.Fare = movieslotDetails.Fare;
            movieslot.MovieDate = movieslotDetails.MovieDate;
            movieslot.MaxSeats = movieslotDetails.MaxSeats;
            movieslot.AvailableSeats = movieslotDetails.AvailableSeats;
            _movieslotService.UpdateMovieSlot(id, movieslot) ;
            return Ok();
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMovieSlot(int id)
        {
            var movieslot = _movieslotService.GetMovieSlot(id);
            if (movieslot == null)
                return NotFound();
            _movieslotService.DeleteMovieSlot(id);
            return Ok();
        }
    }
}
