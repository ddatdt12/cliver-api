using AutoMapper;
using CliverApi.Attributes;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CliverApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _unitOfWork.Posts.GetAll();
            return Ok(new
            {
                data = posts
            });
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _unitOfWork.Posts.FindById(id);
            return Ok(new
            {
                data = post
            });
        }

        // POST api/<PostController>
        [HttpPost]
        [ProtectRoute]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {
            Post p = _mapper.Map<Post>(post);
            var user = HttpContext.Items["User"] as User;

            p.UserId = user!.Id;
            await _unitOfWork.Posts.Add(p);
            await _unitOfWork.CompleteAsync();

            return new CreatedResult
            ("New Post", new
            {
                data = p
            });
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
