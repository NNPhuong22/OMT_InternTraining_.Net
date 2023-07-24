using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2_OMT.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public CommentRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public List<ReplyPost> GetCommentFromPost(int id)
        {
            var comments = _context.ReplyPosts.Where(o => o.PostId == id && o.IsDeleted == 0).Include(o => o.SubReplies);
            return comments.ToList();
        }
        public async Task<ApiResponse<int>> CreateComment(RepplyAddDTO comment, int claim)
        {
            try
            {
                // comment
                if (comment.ReplyId == 0 || comment.ReplyId == null)
                {
                    var postExisted = await _context.Posts.Where(o => o.PostId == comment.PostId && o.IsDeleted == 1).ToListAsync();
                    if (postExisted.Count > 0)
                    {
                        return new ApiResponse<int>
                        {
                            Message = new List<string> {
                    "Bài viết không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    if (comment.Content.Trim() == "" || comment.Content == null)
                    {
                        return new ApiResponse<int>
                        {
                            Message = new List<string> {
                    "Bình luận không được để trống"
                    },
                            Status = 0
                        };
                    }

                    var a = new ReplyPost
                    {
                        Replier = claim,
                        ReplyContent = comment.Content,
                        IsDeleted = 0,
                        PostId = comment.PostId,
                    };
                    _context.Add(a);
                    await _context.SaveChangesAsync();
                    return new ApiResponse<int>
                    {
                        Status = 1
                    };
                }
                // sub comment
                else
                {
                    var commentExisted = await _context.ReplyPosts.Where(o => o.ReplyId == comment.ReplyId && o.IsDeleted == 0).ToListAsync();
                    if (commentExisted.Count > 0)
                    {
                        return new ApiResponse<int>
                        {
                            Message = new List<string> {
                    "Bình luận không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    if (comment.Content.Trim() == "" || comment.Content == null)
                    {
                        return new ApiResponse<int>
                        {
                            Message = new List<string> {
                    "Bình luận không được để trống"
                    },
                            Status = 0
                        };
                    }
                    var a = new SubReply
                    {
                        Replier = claim,
                        SubContent = comment.Content,
                        IsDeleted = 0,
                        ReplyId = (int)comment.ReplyId,

                    };
                    _context.Add(a);
                    await _context.SaveChangesAsync();
                    return new ApiResponse<int>
                    {
                        Status = 1
                    };
                }

            }
            catch (Exception)
            {
                return new ApiResponse<int>
                {
                    Message = new List<string> {
                    "Không thể bình luận"
                    },
                    Status = 0
                };
            }
        }
        public async Task<ApiResponse<ReplyPost>> EditComment(RepplyEditDTO post, int claim)
        {
            try
            {
                if (post.SubId == 0 || post.SubId == null && post.ReplyId != null)
                {
                    var editReply = await _context.ReplyPosts.SingleOrDefaultAsync(o => o.ReplyId == post.ReplyId && o.IsDeleted == 0);
                    if (editReply == null)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Bình luận không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    if (claim != editReply.Replier)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Không phải chủ của bình luận"
                    },
                            Status = 0
                        };
                    }
                    editReply.ReplyContent = post.Content;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<ReplyPost>
                    {
                        Status = 1
                    };
                }
                else
                {
                    var editReply = await _context.SubReplies.SingleOrDefaultAsync(o => o.SubId == post.SubId && o.IsDeleted == 0);
                    if (editReply == null)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Bình luận không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    if (claim != editReply.Replier)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Không phải chủ của bình luận"
                    },
                            Status = 0
                        };
                    }
                    editReply.SubContent = post.Content;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<ReplyPost>
                    {
                        Status = 1
                    };
                }
            }
            catch (Exception)
            {
                return new ApiResponse<ReplyPost>
                {
                    Message = new List<string> {
                    "Không thể sửa bình luận"
                    },
                    Status = 0
                };
            }
        }
        public async Task<ApiResponse<ReplyPost>> DeleteComment(RepplyEditDTO post, int claim)
        {
            try
            {
                if (post.SubId == 0 || post.SubId == null && post.ReplyId != null)
                {
                    var editReply = await _context.ReplyPosts.SingleOrDefaultAsync(o => o.ReplyId == post.ReplyId && o.IsDeleted == 0);
                    if (editReply == null)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Bình luận không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    var user = await _context.Users.SingleOrDefaultAsync(o => o.UserId == claim);
                    if (claim != editReply.Replier || user.Role != 1)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Không phải chủ của bình luận"
                    },
                            Status = 0
                        };
                    }
                    editReply.IsDeleted = 1;
                    var subComment = await _context.SubReplies.Where(o => o.ReplyId == post.ReplyId).ToListAsync();
                    foreach (var item in subComment)
                    {
                        item.IsDeleted = 1;
                    }
                    await _context.SaveChangesAsync();
                    return new ApiResponse<ReplyPost>
                    {
                        Status = 1
                    };
                }
                else
                {
                    var editReply = await _context.SubReplies.SingleOrDefaultAsync(o => o.SubId == post.SubId && o.IsDeleted == 0);
                    if (editReply == null)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Bình luận không tồn tại"
                    },
                            Status = 0
                        };
                    }
                    var user = await _context.Users.SingleOrDefaultAsync(o => o.UserId == claim);
                    if (claim != editReply.Replier || user.Role != 1)
                    {
                        return new ApiResponse<ReplyPost>
                        {
                            Message = new List<string> {
                    "Không phải chủ của bình luận"
                    },
                            Status = 0
                        };
                    }
                    editReply.IsDeleted = 1;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<ReplyPost>
                    {
                        Status = 1
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
