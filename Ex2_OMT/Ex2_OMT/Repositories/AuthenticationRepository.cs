using Ex2_OMT.Auth;
using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2_OMT.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        private readonly IJwtUtils _jwtRepository;
        public AuthenticationRepository(Ex2Context context, IConfiguration configuration, IJwtUtils jwtRepository)
        {
            _context = context;
            _configuration = configuration;
            _jwtRepository = jwtRepository;
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
                    return _jwtRepository.GenerateToken(user);
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
    }
}
