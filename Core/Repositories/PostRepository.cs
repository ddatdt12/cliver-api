using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Error;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CliverApi.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private IMapper _mapper;
        public PostRepository(DataContext context, ILogger logger, IMapper mapper) : base(context, logger)
        {
            _mapper = mapper;
        }

        public async Task Update(int id, UpdatePostDto postData)
        {
            var post = await FindById(id);
            if(post == null)
            {
                throw new HttpResponseException("Post not found", 404);
            }
            _mapper.Map(postData, post);
        }
    }
}
