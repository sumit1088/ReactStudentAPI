using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Data;
using StudentForm.Models;
using System.Security.Cryptography;
using System.Text;

using BCrypt.Net;

namespace StudentForm.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserDetailsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDetails dto)
        {
            // Check if username already exists
            if (await _context.UserDetails.AnyAsync(u => u.username == dto.username))
            {
                return BadRequest("Username already exists.");
            }

            // Hash the password using bcrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.password);

            var user = new UserDetails
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                username = dto.username,
                password = passwordHash,  // Store the hashed password
                createddate = dto.createddate
            };

            _context.UserDetails.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

    }

}


