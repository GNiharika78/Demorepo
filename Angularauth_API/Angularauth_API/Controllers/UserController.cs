using Angularauth_API.Context;
using Angularauth_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angularauth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj )
        {
            if (userObj == null) 
                return BadRequest();
            var user=await _authContext.users.FirstOrDefaultAsync(x=>x.Username==userObj.Username && x.Password==userObj.Password);
            if (user == null)
                return NotFound(new { Message = "User not Found" });
            return Ok(new
            {
                Message = "login success"
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message="User SignedUp"
            });

        }
    }
}
