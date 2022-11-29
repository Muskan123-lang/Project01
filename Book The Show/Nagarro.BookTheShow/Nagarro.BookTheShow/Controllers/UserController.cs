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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        // GET: api/<RegisterController>
        [HttpGet]
        public ActionResult<IEnumerable<UserDetail>> GetAllUser()
        {
            return _userService.GetAllUser().Select(x => new UserDetail { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Email=x.Email,Contact=x.Contact,Gender=x.Gender,Password = x.Password,IsAdmin=x.IsAdmin }).ToList();
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDetail> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            var userDetails = new UserDetail { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName,Email=user.Email,Contact=user.Contact,Gender=user.Gender, Password = user.Password,IsAdmin=user.IsAdmin };
            return userDetails;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public ActionResult CreateUser([FromBody] UserDetail userDetails)
        {
            var user = new Interfaces.Domain.User();
            user.FirstName = userDetails.FirstName;
            user.LastName = userDetails.LastName;
            user.Gender = userDetails.Gender;
            user.Contact = userDetails.Contact;
            user.Email = userDetails.Email;
            user.Password = userDetails.Password;
            
            _userService.CreateUser(user);
            return Ok();

        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserDetail userDetails)
        {
            var user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            user.FirstName = userDetails.FirstName;
            user.LastName = userDetails.LastName;
            user.Gender = userDetails.Gender;
            user.Contact = userDetails.Contact;
            user.Email = userDetails.Email;
            user.Password = userDetails.Password;
            user.IsAdmin = userDetails.IsAdmin;
            _userService.UpdateUser(id, user);
            return Ok();

        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
