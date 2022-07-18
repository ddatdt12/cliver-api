using CliverApi.Core.Contracts;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CliverApi.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DataContext context, ILogger logger) : base(context, logger)
        {

        }


    }
}
