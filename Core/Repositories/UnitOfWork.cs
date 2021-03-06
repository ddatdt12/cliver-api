using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.Models;

namespace CliverApi.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }
        public IAuthRepository Auth { get; private set; }
        public IPostRepository Posts { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(DataContext context, ILoggerFactory loggerFactory
            , IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(context, _logger);
            Posts = new PostRepository(context, _logger, mapper);
            Auth = new AuthRepository(configuration, context, _logger);
            Categories = new CategoryRepository(context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
