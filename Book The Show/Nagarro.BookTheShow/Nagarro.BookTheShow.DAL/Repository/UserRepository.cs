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
    public class UserRepository : IUserRepository
    {
        private readonly BookTheShowContext _dbContext;

        public UserRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(User user)
        {
            EFModels.User st = new EFModels.User {FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, Email = user.Email, Contact=user.Contact,Password = user.Password};
            if (GetUserByEmail(user.Email,user.Password) == null) {
                _dbContext.Add(st);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            _dbContext.Remove(_dbContext.Users.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUser()
        {
            return _dbContext.Users.Select(x => new User { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Gender = x.Gender, Email = x.Email,Contact=x.Contact,Password=x.Password,IsAdmin=x.IsAdmin });
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).Select(x => new User { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Gender = x.Gender, Email=x.Email,Password=x.Password,IsAdmin=x.IsAdmin }).FirstOrDefault();
        }

        public void UpdateUser(int id, User user)
        {
            var userIndex = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            userIndex.FirstName = user.FirstName;
            userIndex.LastName = user.LastName;
            userIndex.Gender = user.Gender;
            userIndex.Email = user.Email;
            userIndex.Contact = user.Contact;
            userIndex.Password = user.Password;
            userIndex.IsAdmin = user.IsAdmin;
            _dbContext.SaveChanges();
        }

        public User GetUserByEmail(string email,string password)
        {
            return _dbContext.Users.Where(x => x.Email == email).Select(x => new User { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Gender = x.Gender, Email = x.Email,Contact=x.Contact, Password = x.Password,IsAdmin=x.IsAdmin }).FirstOrDefault();
        }
    }
}
