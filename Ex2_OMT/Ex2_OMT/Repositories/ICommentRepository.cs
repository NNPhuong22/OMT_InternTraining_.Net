using Ex2_OMT.Models;

namespace Ex2_OMT.Repositories
{
    public interface ICommentRepository
    {
        List<ReplyPost> GetCommentFromPost(int id);
        Task<ApiResponse<int>> CreateComment(RepplyAddDTO post, int claim);
        Task<ApiResponse<ReplyPost>> EditComment(RepplyEditDTO post, int claim);
        Task<ApiResponse<ReplyPost>> DeleteComment(RepplyEditDTO post, int claim);

    }
}
