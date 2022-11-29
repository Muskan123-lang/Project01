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
    public class UserMovieBookController : ControllerBase
    {
        private readonly IUserMovieBookService _usermovieBookService;

        public UserMovieBookController(IUserMovieBookService userService)
        {
            _usermovieBookService = userService;

        }

        // GET: api/<MovieDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<UserMovieBookDetail>> GetAllUserMovie()
        {
            return _usermovieBookService.GetAllUserMovie().Select(x => new UserMovieBookDetail { Id = x.Id,MovieSlotId=x.MovieSlotId,UserId=x.UserId,SeatNos=x.SeatNos,IsActive=x.IsActive,NoOfTickets=x.NoOfTickets,BookingDate=x.BookingDate,Rating=x.Rating }).ToList();
        }


      
        [HttpPost]
        public ActionResult CreateUserMovie([FromBody] UserMovieBookDetail movieDetails)
        {
            var movie = new Interfaces.Domain.UserMovieBook();
            movie.MovieSlotId = movieDetails.MovieSlotId;
            movie.UserId = movieDetails.UserId;
            movie.SeatNos = movieDetails.SeatNos;
            movie.NoOfTickets = movieDetails.NoOfTickets;
            movie.BookingDate = movieDetails.BookingDate;
            movie.Rating = movieDetails.Rating;
            movie.IsActive = movieDetails.IsActive;
            _usermovieBookService.CreateUserMovie(movie);
            return Ok();
        }


        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<UserMovieBookDetail> GetUserMovie(int id)
        {
            var movieBook = _usermovieBookService.GetUserMovie(id);
            if (movieBook == null)
                return NotFound();
            var movieBookDetails = new UserMovieBookDetail { Id = movieBook.Id, UserId=movieBook.UserId,MovieSlotId=movieBook.MovieSlotId,SeatNos=movieBook.SeatNos,IsActive=movieBook.IsActive,NoOfTickets=movieBook.NoOfTickets,BookingDate=movieBook.BookingDate,Rating=movieBook.Rating};
            return movieBookDetails;
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUserMovie(int id)
        {
            var movie = _usermovieBookService.GetUserMovie(id);
            if (movie == null)
                return NotFound();
            _usermovieBookService.DeleteUserMovie(id);
            return Ok();
        }
    }
}
