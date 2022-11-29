using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IMovieSlotService
    {
        public IEnumerable<MovieSlot> GetAllMovieSlot();

        public MovieSlot GetMovieSlot(int id);

        public void CreateMovieSlot(MovieSlot movieslot);

        public void UpdateMovieSlot(int id, MovieSlot movieslot);

        public void DeleteMovieSlot(int id);
    }
}
