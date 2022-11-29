using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovie();

        public Movie GetMovie(int id);

        public void CreateMovie(Movie movie);

        public void UpdateMovie(int id, Movie movie);

        public void DeleteMovie(int id);
    }
}
