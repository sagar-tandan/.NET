using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UserDTOs;
using api.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers.UserControllers
{

    [Route("api/Users")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public SignUpController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Createuser([FromBody] SignUpDTO signUpDTO)
        {

            if (signUpDTO.Password == signUpDTO.ConfirmPassword)
            {
                var newUser = new User
                {
                    Username = signUpDTO.Username,
                    Email = signUpDTO.Email,
                    Password = signUpDTO.Password
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return StatusCode(200, "User Created Successfully!!");

            }

            return BadRequest("Password didn't match!!");

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            if (allUsers == null)
            {
                return NotFound();
            }

            var UsersToShow = allUsers.Select(user => new SignUpDTO
            {
                Username = user.Username,
                Email = user.Email
            });

            return Ok(UsersToShow);

        }
    }
}