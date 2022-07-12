using CliverApi.Core.IRepositories;

namespace CliverApi.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
