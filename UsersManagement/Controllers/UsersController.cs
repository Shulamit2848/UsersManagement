using BL;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Application.Services;
using UsersManagement.Entities;

namespace UsersManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBl _userBl;

        public UsersController(IUserBl userService)
        {
            _userBl = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if model validation fails
            }

            var createdUser = await _userBl.CreateUserAsync(user);
            return Ok(createdUser);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userBl.DeleteUserAsync(id);
            return NoContent(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByCredentialsAsync(string userName, string password)
        {
            var user = await _userBl.GetUserByCredentialsAsync(userName, password);
            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(user);
        }
    }


}
