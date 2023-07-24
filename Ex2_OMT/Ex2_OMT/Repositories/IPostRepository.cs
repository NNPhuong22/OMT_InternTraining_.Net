using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface IPostRepository
    {
        Task<ResponseData<Post>> GetAll(string? search = "", int? categoryId = null, int page = 1);
        Task<ResponseData<Post>> GetPost(int id);
        Task<ApiResponse<Post>> CreatePost(PostAddDTO post, int claim);
        Task<ApiResponse<Post>> EditPost(PostEditDTO post, int claim, int role);

        Task<ApiResponse<Post>> DeletePost(int id, int claim, int role);
    }
}
