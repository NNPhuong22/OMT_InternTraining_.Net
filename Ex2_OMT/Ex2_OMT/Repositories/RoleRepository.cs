using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2_OMT.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public RoleRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ApiResponse<RoleDTO>> AddRole(RoleDTO role)
        {
            var checkRole = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName.ToLower() == role.RoleName.ToLower());
            if (checkRole != null)
            {
                return new ApiResponse<RoleDTO>
                {
                    Message = new List<string> {
                    "Danh mục đã tồn tại"
                    },
                    Status = 0
                };
            }
            else
            {
                _context.Add(new Role { RoleName = role.RoleName });
                await _context.SaveChangesAsync();
                return new ApiResponse<RoleDTO>
                {
                    Data = role,
                    Status = 1
                };
            }
        }

        public async Task<ApiResponse<User>> ChangeUserRole(int id, int role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user != null)
            {
                user.Role = role;
                await _context.SaveChangesAsync();
                return new ApiResponse<User>
                {
                    Data = user,
                    Status = 1
                };
            }
            return new ApiResponse<User>
            {
                Message = new List<string> {
                    "Người dùng hoặc quyền không tồn tại."
                    },
                Status = 0
            };
        }

        public async Task<List<Role>> GetAllRole()
        {
            var roleList = await _context.Roles.ToListAsync();
            return roleList;
        }
    }
}
