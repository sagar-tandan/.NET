// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace api.Controllers.UserControllers
// {

//     [Route("api/login")]
//     [ApiController]
//     public class LoginController : ControllerBase
//     {

//         private readonly ApplicationDBContext _context;
//         public LoginController(ApplicationDBContext context)
//         {
//             _context = context;
//         }

//         [HttpPost]
//         public async Task<IActionResult> UserLogin([FromBody] LoginDTO loginDTO)
//         {
//             var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDTO.Username);

//             if (user == null)
//             {
//                 return NotFound();
//             }
//             if (BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
//             {
//                 return Ok("Logged In!!");
//             }
//             return BadRequest("Credentials didn't matched!!");



//         }
//     }
// }