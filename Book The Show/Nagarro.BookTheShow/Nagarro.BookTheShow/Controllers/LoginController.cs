using Microsoft.AspNetCore.Mvc;
using Nagarro.BookTheShow.Interfaces.Service;
using Nagarro.BookTheShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nagarro.BookTheShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;

        }


        // GET: api/<LoginController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<LoginController>/5
        [HttpGet("{email}")]
        public ActionResult<UserDetail> GetUserByEmail(string email, string password)
        {
            var user = _userService.GetUserByEmail(email,password);
            if (user == null)
                return NotFound();
            var userDetails = new UserDetail { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName,Gender=user.Gender,Contact=user.Contact,Email=user.Email, Password = user.Password, IsAdmin=user.IsAdmin };
            return userDetails;
        }
    }
}
