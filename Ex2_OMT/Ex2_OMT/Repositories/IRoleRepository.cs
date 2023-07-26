using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface IRoleRepository
    {
        Task<ApiResponse<Role>> AddRole();
        Task<ApiResponse<Role>> ChangeUserRole(int id);
    }
}
