using Nagarro.BookTheShow.DAL.Data.DbContexts;
using Nagarro.BookTheShow.Interfaces.Domain;
using Nagarro.BookTheShow.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.DAL.Repository
{
    public class UserMovieBookRepository : IUserMovieBookRepository
    {
        private readonly BookTheShowContext _dbContext;

        public UserMovieBookRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUserMovie(UserMovieBook movie)
        {
            EFModels.UserMovieBook st = new EFModels.UserMovieBook {MovieSlotId=movie.MovieSlotId,UserId=movie.UserId,SeatNos=movie.SeatNos,IsActive = movie.IsActive,NoOfTickets=movie.NoOfTickets,BookingDate=movie.BookingDate,Rating=movie.Rating };
            _dbContext.Add(st);
            _dbContext.SaveChanges();
        }

        public void DeleteUserMovie(int id)
        {
            _dbContext.Remove(_dbContext.UserMovieBooks.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserMovieBook> GetAllUserMovie()
        {
            return _dbContext.UserMovieBooks.Select(x => new UserMovieBook { Id = x.Id, MovieSlotId=x.MovieSlotId,UserId=x.UserId,SeatNos = x.SeatNos, IsActive = x.IsActive, NoOfTickets = x.NoOfTickets, BookingDate = x.BookingDate, Rating = x.Rating });
        }

        public UserMovieBook GetUserMovie(int id)
        {
            return _dbContext.UserMovieBooks.Where(x => x.Id == id).Select(x => new UserMovieBook { Id = x.Id, MovieSlotId=x.MovieSlotId,UserId=x.UserId,SeatNos = x.SeatNos, IsActive = x.IsActive, NoOfTickets = x.NoOfTickets, BookingDate = x.BookingDate, Rating = x.Rating }).FirstOrDefault();
        }

        public void UpdateUserMovie(int id, UserMovieBook movie)
        {
            var movieIndex = _dbContext.UserMovieBooks.Where(x => x.Id == id).FirstOrDefault();
            movieIndex.SeatNos = movie.SeatNos;
            movieIndex.NoOfTickets = movie.NoOfTickets;
            movieIndex.BookingDate = movie.BookingDate;
            movieIndex.IsActive = movie.IsActive;
            movieIndex.Rating = movie.Rating;
            _dbContext.SaveChanges();
        }
    }
}
