using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByEmailAndPassword(string email, string password);
        Task<User> FindByEmail(string email);
    }
}
