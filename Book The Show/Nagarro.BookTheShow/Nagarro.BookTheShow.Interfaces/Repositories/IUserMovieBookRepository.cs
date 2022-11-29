using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Repositories
{
     public interface IUserMovieBookRepository
    {
        public IEnumerable<UserMovieBook> GetAllUserMovie();

        public UserMovieBook GetUserMovie(int id);

        public void CreateUserMovie(UserMovieBook movie);

        public void UpdateUserMovie(int id, UserMovieBook movie);

        public void DeleteUserMovie(int id);
    }
}
