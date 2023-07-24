using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseData<Models.User>> GetAll(string? search = "", int? role = null, int page = 1, int? isDisabled = null);
        Task<ApiResponse<User>> DisableUser(int id);
        Task<ApiResponse<User>> EnableUser(int id);
        Task<ApiResponse<User>> ChangePassword(PasswordDTO pass, int claim);
        Task<ApiResponse<User>> Register(UserAddDTO user);
        Task<ApiResponse<User>> CreateStaff(UserAddDTO user);
        Task<ApiResponse<User>> GetUser(int id);
    }
}
