using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface ICategoryRepository
    {
        Task<ResponseData<Category>> GetAll(string? search = "", int? isDeleted = null, int page = 1);
        Task<ApiResponse<Category>> GetCategory(int id);
        Task<ApiResponse<Category>> CreateCategory(string category);
        Task<ApiResponse<Category>> EditCategory(CategoryDTO category);

        Task<ApiResponse<Category>> DisableCategory(int id);


    }
}
