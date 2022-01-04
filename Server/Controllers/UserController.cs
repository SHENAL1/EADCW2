using CW2.Server.Data;
using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return base.Ok(await GetDbUser());
        }

        private async Task<List<User>> GetDbUser()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUser());
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(User user, int id)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (dbUser == null)
            {
                return NotFound("The User is not in the system");
            }

            dbUser.UserId = user.UserId;
            dbUser.UserName = user.UserName;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.UserEmail = user.UserEmail;
            dbUser.UserPhoneNo = user.UserPhoneNo;
            dbUser.UserType = user.UserType;

            await _context.SaveChangesAsync();
            return Ok(await GetDbUser());


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (dbUser == null)
            {
                return NotFound("The User is not in the system");
            }

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(await GetDbUser());


        }
    }
}
