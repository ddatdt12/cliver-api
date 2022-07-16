using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface IAuthRepository
    {
        string GenerateToken(User user);
    }
}
