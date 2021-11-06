using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SohatNotebook.DataService.Data;
using SohatNotebook.Entities.DbSet;
using SohatNotebook.Api;
using SohatNotebook.Entities.Dtos.Incoming;
using System;

namespace SohatNotebook.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext _context;
        
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // Get
        [HttpGet]
        
        public IActionResult GetUsers()
        {
            var users = _context.Users.Where(x => x.Status ==1).ToList();
            return Ok(users);
        }

        // Post
        [HttpPost]

        public IActionResult AddUser(UserDto user)
        {
            var _user = new User();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Email = user.Email;
            _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
            _user.Phone = user.Phone;
            _user.Country = user.Country; 
            _user.Status = 1;

            _context.Users.Add(_user);
            _context.SaveChanges();

            return Ok(); // return 201
    }
           // Get All
     
    }
}