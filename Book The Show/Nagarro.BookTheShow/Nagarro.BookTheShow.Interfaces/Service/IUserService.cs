using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUser();

        public User GetUser(int id);

        public void CreateUser(User user);

        public void UpdateUser(int id, User user);

        public void DeleteUser(int id);

        public User GetUserByEmail(string email, string password);
    }
}
