using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UserDTOs;
using api.DTOs.UserDTOs.SignUpDTO;
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


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            if (allUsers == null)
            {
                return NotFound();
            }

            var UsersToShow = allUsers.Select(user => new ViewUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            });

            return Ok(UsersToShow);

        }


        [HttpPost]

        public async Task<IActionResult> Createuser([FromBody] CreateUserDTO createUserDTO)
        {

            var serachUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == createUserDTO.Username);
            if (serachUser == null)
            {
                if (createUserDTO.Password == createUserDTO.ConfirmPassword)
                {
                    var newUser = new User
                    {
                        Username = createUserDTO.Username,
                        Email = createUserDTO.Email,
                        Password = createUserDTO.Password
                    };

                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                    return StatusCode(200, "User Created Successfully!!");

                }
                else
                {
                    return BadRequest("Password didn't match!!");

                }

            }
            return BadRequest("Username already Exists!!");


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            var registeredUser = await _context.Users.FindAsync(id);
            if (registeredUser == null)
            {
                return BadRequest();
            }
            registeredUser.Username = updateUserDTO.Username;
            registeredUser.Email = updateUserDTO.Email;
            registeredUser.Password = updateUserDTO.Password;

            _context.Entry(registeredUser).State = EntityState.Modified;
            try
            {

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return StatusCode(200, "User Updated Successfully!!");

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var UserToDelete = await _context.Users.FindAsync(id);
            if (UserToDelete == null)
            {
                return NotFound();
            }

            _context.Users.Remove(UserToDelete);
            await _context.SaveChangesAsync();

            return Ok("User Deleted Successfully!!");

        }
    }
}