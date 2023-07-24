using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2_OMT.Repositories
{
    public class PostRepository : IPostRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public PostRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseData<Post>> GetAll(string search = "", int? categoryId = null, int page = 1)
        {
            var query = _context.Posts.Where(o => o.IsDeleted == 0)
                .Where(o => o.PostName.ToLower().Trim().Contains(search.ToLower().Trim())
                || o.PostContent.ToLower().Trim().Contains(search.ToLower().Trim()))
                .Where(o => o.CategoryId == categoryId || categoryId == null).Include(o => o.ReplyPosts).ThenInclude(o => o.SubReplies);
            var a = await query.CountAsync();
            var result = await query.Skip((page - 1) * 5).Take(5).ToListAsync();

            var pageNum = (int)Math.Ceiling((decimal)a / 5);
            if (page < 1 || page > pageNum)
            {
                return new ResponseData<Post>
                {
                    mess = "Số trang vượt quá trang tối đa"
                };
            }
            return new ResponseData<Post>
            {
                CurrentPage = page,
                TotalPage = pageNum,
                Data = result
            };
        }

        public async Task<ResponseData<Post>> GetPost(int id)
        {
            var post = await _context.Posts.Where(o => o.PostId == id)
                .Include(o => o.ReplyPosts).ThenInclude(o => o.SubReplies).ToListAsync();
            if (post != null)
            {
                return new ResponseData<Post>
                {
                    Data = post
                };
            }
            else
            {
                return new ResponseData<Post>
                {
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<Post>> CreatePost(PostAddDTO post, int claim)
        {
            try
            {
                if (claim == 0)
                {
                    return new ApiResponse<Post>
                    {
                        Message = new List<string> {
                    "Phải đăng nhập để thêm bài viết"
                    },
                        Status = 0
                    };
                }
                if (_context.Categories.SingleOrDefault(o => o.CategoryId == post.CategoryId) == null)
                {
                    return new ApiResponse<Post>
                    {
                        Message = new List<string> {
                    "Danh mục không tồn tại"
                    },
                        Status = 0
                    };
                }
                _context.Add(new Post
                {
                    PostName = post.PostName,
                    PostContent = post.PostContent,
                    Created = claim,
                    CreatedDate = DateTime.Now,
                    CategoryId = post.CategoryId,
                    IsDeleted = 0,
                });
                await _context.SaveChangesAsync();
                return new ApiResponse<Post>
                {
                    Message = new List<string> { "Thêm bài viết thành công" },
                    Status = 1
                };
            }
            catch (Exception)
            {
                return new ApiResponse<Post>
                {
                    Message = new List<string> {
                    "Không thể thêm bài viết"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<Post>> EditPost(PostEditDTO post, int claim, int role)
        {
            try
            {
                var editedPost = await _context.Posts.SingleOrDefaultAsync(o => o.PostId == post.PostId && o.IsDeleted == 0);
                if (editedPost != null)
                {
                    if (editedPost.Created == claim || role == 1)
                    {
                        editedPost.PostContent = post.PostContent;
                        editedPost.PostName = post.PostName;
                        editedPost.CategoryId = post.CategoryId;
                        await _context.SaveChangesAsync();
                        return new ApiResponse<Post>
                        {
                            Message = new List<string> {
                    "Sửa bài viết thành công"
                    },
                            Status = 1
                        };
                    }
                    else
                    {
                        return new ApiResponse<Post>
                        {
                            Message = new List<string> {
                    "Không thể sửa bài viết"
                    },
                            Status = 0
                        };
                    }
                }
                else
                {
                    return new ApiResponse<Post>
                    {
                        Message = new List<string> {
                    "Bài viết không tồn tại"
                    },
                        Status = 0
                    };
                }
            }
            catch (Exception)
            {
                return new ApiResponse<Post>
                {
                    Message = new List<string> {
                    "Không thể sửa bài viết"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<Post>> DeletePost(int id, int claim, int role)
        {
            try
            {
                var post = await _context.Posts.SingleOrDefaultAsync(o => o.PostId == id);
                if (post != null)
                {
                    if (post.Created == claim || role == 1)
                    {
                        post.IsDeleted = 1;

                        var comment = await _context.ReplyPosts.Where(o => o.PostId == id).Include(o => o.SubReplies).ToListAsync();

                        foreach (var item in comment)
                        {
                            item.IsDeleted = 1;
                            foreach (var o in item.SubReplies)
                            {
                                o.IsDeleted = 1;
                            }
                        }
                        await _context.SaveChangesAsync();
                        return new ApiResponse<Post>
                        {
                            Message = new List<string> {
                    "Xóa bài viết thành công"
                    },
                            Status = 1
                        };
                    }
                    return new ApiResponse<Post>
                    {
                        Message = new List<string> {
                    "Không thể xóa bài viết"
                    },
                        Status = 0
                    };
                }
                else
                {
                    return new ApiResponse<Post>
                    {
                        Message = new List<string> {
                    "Bài viết không tồn tại"
                    },
                        Status = 0
                    };
                }
            }
            catch (Exception)
            {
                return new ApiResponse<Post>
                {
                    Message = new List<string> {
                    "Không thể thêm bài viết"
                    },
                    Status = 0
                };
            }
        }
    }
}
