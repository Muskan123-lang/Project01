using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IMovieListingService
    {
        public IEnumerable<MovieListing> GetAllMovieListing();

        public MovieListing GetMovieListing(int id);

        public void CreateMovieListing(MovieListing movieslot);

        public void UpdateMovieListing(int id, MovieListing movieslot);

        public void DeleteMovieListing(int id);
    }
}
