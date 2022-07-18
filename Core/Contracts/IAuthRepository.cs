using CliverApi.Models;

namespace CliverApi.Core.Contracts
{
    public interface IAuthRepository
    {
        string GenerateToken(User user);
        string? ValidateToken(string token);
    }
}
