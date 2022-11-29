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
    public class MovieSlotRepository : IMovieSlotRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieSlotRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateMovieSlot(MovieSlot movieslot)
        {
            EFModels.MovieSlot st = new EFModels.MovieSlot { MovieId=movieslot.MovieId,MovieTime = movieslot.MovieTime, Fare=movieslot.Fare,MovieDate=movieslot.MovieDate,MaxSeats=movieslot.MaxSeats,AvailableSeats=movieslot.AvailableSeats };
            _dbContext.Add(st);
            _dbContext.SaveChanges();
        }

        public void DeleteMovieSlot(int id)
        {
            _dbContext.Remove(_dbContext.MovieSlots.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieSlot> GetAllMovieSlot()
        {
            return _dbContext.MovieSlots.Select(x => new MovieSlot { Id = x.Id, MovieId=x.MovieId,MovieTime = x.MovieTime, Fare = x.Fare, MovieDate = x.MovieDate, MaxSeats = x.MaxSeats,AvailableSeats=x.AvailableSeats });
        }

        public MovieSlot GetMovieSlot(int id)
        {
            return _dbContext.MovieSlots.Where(x => x.Id == id).Select(x => new MovieSlot { Id = x.Id, MovieId=x.MovieId,MovieTime = x.MovieTime, Fare = x.Fare, MovieDate = x.MovieDate, MaxSeats = x.MaxSeats,AvailableSeats=x.AvailableSeats }).FirstOrDefault();
        }

        public void UpdateMovieSlot(int id, MovieSlot movieslot)
        {
            var movieslotIndex = _dbContext.MovieSlots.Where(x => x.Id == id).FirstOrDefault();
            movieslotIndex.MovieId = movieslot.MovieId;
            movieslotIndex.MovieTime = movieslot.MovieTime;
            movieslotIndex.Fare = movieslot.Fare;
            movieslotIndex.MovieDate = movieslot.MovieDate;
            movieslotIndex.MaxSeats = movieslot.MaxSeats;
            movieslotIndex.AvailableSeats = movieslot.AvailableSeats;
            _dbContext.SaveChanges();
        }
    }
}
