using CliverApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CliverApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DataContext _context;

        public UserController(ILogger<UserController> logger, DataContext context)
        {
            _logger = logger;
            _context=context;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            _logger.LogWarning("Something went wrong!");
            return new List<User>();
            //return _context.Users.ToList();
        }
    }
}