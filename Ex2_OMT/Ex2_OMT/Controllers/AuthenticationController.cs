using Ex2_OMT.Models;
using Ex2_OMT.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ex2_OMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var login = await _authenticationRepository.Login(model);
            return Ok(login);
        }
    }
}
