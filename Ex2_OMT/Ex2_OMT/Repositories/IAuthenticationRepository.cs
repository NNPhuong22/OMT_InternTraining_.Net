using Ex2_OMT.Models;
namespace Ex2_OMT.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<string> Login(LoginModel model);

    }
}
