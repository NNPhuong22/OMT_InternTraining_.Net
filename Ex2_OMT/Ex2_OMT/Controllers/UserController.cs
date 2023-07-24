using Ex2_OMT.Models;
using Ex2_OMT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string? search = "", int? role = null, int page = 1)
        {
            var users = await _userRepository.GetAll(search, role, page);
            return Ok(users);
        }
        [Authorize(Policy = "Admin")]
        [HttpPut("Disable")]
        public async Task<IActionResult> DisableUser(int id)
        {
            var users = await _userRepository.DisableUser(id);
            return Ok(users);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Enable")]
        public async Task<IActionResult> EnableUser(int id)
        {
            var users = await _userRepository.EnableUser(id);
            return Ok(users);
        }
        [Authorize(Policy = "Both")]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(PasswordDTO password)
        {
            var userId = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var users = await _userRepository.ChangePassword(password, userId);
            return Ok(users);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserAddDTO user)
        {
            var userRegister = await _userRepository.Register(user);
            return Ok(userRegister);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateStaff(UserAddDTO user)
        {
            var userRegister = await _userRepository.CreateStaff(user);
            return Ok(userRegister);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userRegister = await _userRepository.GetUser(id);
            return Ok(userRegister);
        }
    }
}
