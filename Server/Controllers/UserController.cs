using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        static List<User> users = new List<User>
        {
            new User { UserId= 1, UserName = "Shenal123", FirstName ="Shenal", LastName ="Anthony", UserEmail ="shenal@gmail.com", UserPhoneNo = "0112956244", UserType = "Admin"},
            new User { UserId= 2, UserName = "Arosha123", FirstName ="Arosha", LastName ="Mendis", UserEmail ="Arosha@gmail.com", UserPhoneNo = "0112956255", UserType = "Developer"}
        };

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound("The User is not in the system");
            }
            else
            {
                return Ok(user);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            user.UserId = users.Max(u => u.UserId + 1);
            users.Add(user);

            return Ok(users);
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(User user, int id)
        {
            var dbUser = users.FirstOrDefault(u => u.UserId == id);
            if (dbUser == null)
            {
                return NotFound("The User is not in the system");
            }

            dbUser = user;

            return Ok(users);


        }
    }
}
