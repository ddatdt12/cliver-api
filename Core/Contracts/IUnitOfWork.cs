using CliverApi.Core.Contracts;

namespace CliverApi.Core.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAuthRepository Auth { get; }
        Task CompleteAsync();
    }
}
