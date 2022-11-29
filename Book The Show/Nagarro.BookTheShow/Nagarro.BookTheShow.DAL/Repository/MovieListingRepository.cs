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
    public class MovieListingRepository : IMovieListingRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieListingRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateMovieListing(MovieListing movieslot)
        {
            EFModels.MovieListing st = new EFModels.MovieListing { MovieName=movieslot.MovieName,MovieDescription=movieslot.MovieDescription,MovieImage=movieslot.MovieImage,MovieTime = movieslot.MovieTime, Fare = movieslot.Fare, MovieDate = movieslot.MovieDate, MaxSeats = movieslot.MaxSeats, AvailableSeats = movieslot.AvailableSeats };
            _dbContext.Add(st);
            _dbContext.SaveChanges();
        }

        public void DeleteMovieListing(int id)
        {
            _dbContext.Remove(_dbContext.MovieListings.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieListing> GetAllMovieListing()
        {
            return _dbContext.MovieListings.Select(x => new MovieListing { Id = x.Id, MovieName=x.MovieName,MovieImage=x.MovieImage,MovieDescription=x.MovieDescription, MovieTime = x.MovieTime, Fare = x.Fare, MovieDate = x.MovieDate, MaxSeats = x.MaxSeats, AvailableSeats = x.AvailableSeats });
        }

        public MovieListing GetMovieListing(int id)
        {
            return _dbContext.MovieListings.Where(x => x.Id == id).Select(x => new MovieListing { Id = x.Id, MovieName=x.MovieName,MovieDescription=x.MovieDescription,MovieImage=x.MovieImage, MovieTime = x.MovieTime, Fare = x.Fare, MovieDate = x.MovieDate, MaxSeats = x.MaxSeats, AvailableSeats = x.AvailableSeats }).FirstOrDefault();
        }

        public void UpdateMovieListing(int id, MovieListing movieslot)
        {
            var movieslotIndex = _dbContext.MovieListings.Where(x => x.Id == id).FirstOrDefault();
            movieslotIndex.MovieName = movieslot.MovieName;
            movieslotIndex.MovieDescription = movieslot.MovieDescription;
            movieslotIndex.MovieImage = movieslot.MovieImage;
            movieslotIndex.MovieTime = movieslot.MovieTime;
            movieslotIndex.Fare = movieslot.Fare;
            movieslotIndex.MovieDate = movieslot.MovieDate;
            movieslotIndex.MaxSeats = movieslot.MaxSeats;
            movieslotIndex.AvailableSeats = movieslot.AvailableSeats;
            _dbContext.SaveChanges();
        }
    }
}
