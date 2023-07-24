using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ex2_OMT.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public CategoryRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResponseData<Category>> GetAll(string search = "", int? isDeleted = null, int page = 1)
        {
            var query = _context.Categories.Where(o => o.IsDeleted == isDeleted || isDeleted == null)
                                           .Where(o => o.CategoryName.ToLower().Trim().Contains(search.ToLower().Trim()));
            var a = await query.CountAsync();
            var result = await query.Skip((page - 1) * 10).Take(10).ToListAsync();

            var pageNum = (int)Math.Ceiling((decimal)a / 10);
            if (page < 1 || page > pageNum)
            {
                return new ResponseData<Category>
                {
                    mess = "Số trang vượt quá trang tối đa"
                };
            }
            return new ResponseData<Category>
            {
                CurrentPage = page,
                TotalPage = pageNum,
                Data = result
            };
        }

        public async Task<ApiResponse<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(o => o.CategoryId == id);
            if (category != null)
            {
                return new ApiResponse<Category>
                {
                    Data = category,
                    Status = 1
                };
            }
            else
            {
                return new ApiResponse<Category>
                {
                    Message = new List<string> {
                    "Danh mục không tồn tại"
                    },
                    Status = 0
                };
            }
        }
        public async Task<ApiResponse<Category>> CreateCategory(string categoryName)
        {
            try
            {
                var category = await _context.Categories.SingleOrDefaultAsync(o => o.CategoryName == categoryName && o.IsDeleted == 0);
                if (category != null)
                {
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Danh mục đã tồn tại"
                    },
                        Status = 0
                    };
                }
                else
                {
                    _context.Add(new Category { CategoryName = categoryName, IsDeleted = 0 });
                    await _context.SaveChangesAsync();
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Thêm danh mục thành công"
                    },
                        Status = 1
                    };

                }
            }
            catch (Exception)
            {
                return new ApiResponse<Category>
                {
                    Message = new List<string> {
                    "Không thể thêm danh mục"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<Category>> DisableCategory(int id)
        {
            try
            {
                var category = await _context.Categories.SingleOrDefaultAsync(o => o.CategoryId == id);
                if (category != null)
                {
                    category.IsDeleted = 1;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Xóa danh mục thành công"
                    },
                        Status = 1
                    };
                }
                else
                {
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Danh mục không tồn tại"
                    },
                        Status = 0
                    };
                }
            }
            catch (Exception)
            {
                return new ApiResponse<Category>
                {
                    Message = new List<string> {
                    "Không thể thêm danh mục"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<Category>> EditCategory(CategoryDTO category)
        {
            try
            {
                var editedCategory = await _context.Categories.SingleOrDefaultAsync(o => o.CategoryId == category.CategoryId && o.IsDeleted == 0);
                if (editedCategory != null)
                {
                    editedCategory.CategoryName = category.CategoryName;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Sửa danh mục thành công"
                    },
                        Status = 1
                    };
                }
                else
                {
                    return new ApiResponse<Category>
                    {
                        Message = new List<string> {
                    "Danh mục không tồn tại"
                    },
                        Status = 0
                    };
                }
            }
            catch (Exception)
            {
                return new ApiResponse<Category>
                {
                    Message = new List<string> {
                    "Không thể sửa danh mục"
                    },
                    Status = 0
                };
            }
        }
    }
}
