using Ex2_OMT.Models;
using Ex2_OMT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string? search = "", int? categoryId = null, int page = 1)
        {
            var category = await _postRepository.GetAll(search, categoryId, page);
            return Ok(category);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Delete")]
        public async Task<IActionResult> DisablePost(int id)
        {
            var userId = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var role = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var post = await _postRepository.DeletePost(id, userId, role);
            return Ok(post);
        }

        [Authorize(Policy = "Both")]
        [HttpPost("GetPost")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(post);
        }

        [Authorize(Policy = "Both")]
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(PostAddDTO post)
        {
            var a = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var postCreated = await _postRepository.CreatePost(post, a);
            return Ok(postCreated);
        }

        [Authorize(Policy = "Both")]
        [HttpPut("EditPost")]
        public async Task<IActionResult> EditPost(PostEditDTO post)
        {
            var userId = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var role = Int32.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);
            var postEdited = await _postRepository.EditPost(post, userId, role);
            return Ok(postEdited);
        }
    }
}
