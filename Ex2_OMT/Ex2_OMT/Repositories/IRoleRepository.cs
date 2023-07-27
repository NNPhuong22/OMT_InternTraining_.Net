using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRole();
        Task<ApiResponse<RoleDTO>> AddRole(RoleDTO role);
        Task<ApiResponse<User>> ChangeUserRole(int id, int role);
    }
}
