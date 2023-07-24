using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ex2_OMT.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public AuthenticationRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> Login(LoginModel model)
        {
            try
            {
                User user = new User();
                if (model != null)
                {
                    user = await _context.Users.SingleOrDefaultAsync(o => o.UserName == model.userName && o.Password == model.password);
                }
                if (user != null && user.IsDisabled == 0)
                {
                    return GenerateToken(user);
                }
                else if (user == null)
                {
                    return "Sai tên đăng nhập hoặc mật khẩu";
                }
                else if (user.IsDisabled == 1)
                {
                    return "Tài khoản bị vô hiệu hóa";
                }
                return "Sai tên đăng nhập hoặc mật khẩu";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        private string GenerateToken(User user)
        {
            var claims = new[]
 {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Role", user.Role.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(12),
                    signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
