using Ex2_OMT.Models;
using Ex2_OMT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet("GetCommentFromPost")]
        public async Task<IActionResult> GetAll(int id)
        {
            var comments = _commentRepository.GetCommentFromPost(id);

            return Ok(comments);
        }

        [Authorize(Policy = "Both")]
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(RepplyAddDTO post)
        {
            int a = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var commentCreated = await _commentRepository.CreateComment(post, a);
            return Ok(commentCreated);
        }

        [Authorize(Policy = "Both")]
        [HttpPut("EditComment")]
        public async Task<IActionResult> EditComment(RepplyEditDTO post)
        {
            int a = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var commentCreated = await _commentRepository.EditComment(post, a);
            return Ok(commentCreated);
        }

        [Authorize(Policy = "Both")]
        [HttpPut("DeleteComment")]
        public async Task<IActionResult> DisableUser(RepplyEditDTO post)
        {
            int a = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);

            var users = await _commentRepository.DeleteComment(post, a);
            return Ok(users);
        }
    }
}
