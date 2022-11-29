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
    public class MovieRepository : IMovieRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateMovie(Movie movie)
        {
            EFModels.Movie st = new EFModels.Movie { MovieName = movie.MovieName,MovieDescription=movie.MovieDescription, MovieImage=movie.MovieImage,IsActive=movie.IsActive };
            _dbContext.Add(st);
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            _dbContext.Remove(_dbContext.Movies.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            return _dbContext.Movies.Select(x => new Movie { Id = x.Id, MovieName=x.MovieName,MovieDescription=x.MovieDescription,MovieImage=x.MovieImage,IsActive=x.IsActive});
        }

        public Movie GetMovie(int id)
        {
            return _dbContext.Movies.Where(x => x.Id == id).Select(x => new Movie { Id = x.Id, MovieName = x.MovieName, MovieDescription = x.MovieDescription, MovieImage = x.MovieImage, IsActive = x.IsActive }).FirstOrDefault();
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var movieIndex = _dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
            movieIndex.MovieName = movie.MovieName;
            movieIndex.MovieDescription = movie.MovieDescription;
            movieIndex.MovieImage = movie.MovieImage;
            movieIndex.IsActive = movie.IsActive;
            _dbContext.SaveChanges();
        }
    }
}
