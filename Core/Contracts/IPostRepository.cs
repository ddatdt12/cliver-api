using CliverApi.DTOs;
using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task Update(int id, UpdatePostDto post);
    }
}
