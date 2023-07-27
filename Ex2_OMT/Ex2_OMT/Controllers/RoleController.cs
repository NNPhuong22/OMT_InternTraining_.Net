using Ex2_OMT.Models;
using Ex2_OMT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ex2_OMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepository.GetAllRole();
            return Ok(roles);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleDTO role)
        {
            var roleAdd = await _roleRepository.AddRole(role);
            return Ok(roleAdd);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole(int userId, int role)
        {
            var roleChange = await _roleRepository.ChangeUserRole(userId, role);
            return Ok(roleChange);
        }
    }
}
