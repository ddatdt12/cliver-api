using AutoMapper;
using CliverApi.Attributes;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
            var posts = await _unitOfWork.Posts.Find(includeProperties: "User").ToListAsync();

            var postDtos = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);

            return Ok(new
            {
                data = postDtos
            });
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _unitOfWork.Posts.FindById(id);
            PostDto postDto = _mapper.Map<PostDto>(post);
            return Ok(new
            {
                data = postDto
            });
        }

        // POST api/<PostController>
        [HttpPost]
        [Protect]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {
            Post p = _mapper.Map<Post>(post);
            var user = HttpContext.Items["User"] as User;

            p.UserId = user!.Id;
            await _unitOfWork.Posts.Add(p);
            await _unitOfWork.CompleteAsync();
            PostDto postDto = _mapper.Map<PostDto>(p);
            return new CreatedResult
            ("New Post", new
            {
                data = postDto
            });
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePostDto Post)
        {
            await _unitOfWork.Posts.Update(id, Post);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
