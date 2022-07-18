using CliverApi.Core.Contracts;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CliverApi.Core.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context, ILogger logger) : base(context, logger)
        {

        }


    }
}
