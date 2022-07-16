using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CliverApi.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthController(ILogger<AuthController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }


    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
      var user = await _unitOfWork.Users.FindUserByEmailAndPassword(email, password);

      if (user == null)
      {
        return NotFound();
      }

      string token = _unitOfWork.Auth.GenerateToken(user);
      UserDto userDto = _mapper.Map<UserDto>(user);

      return Ok(new
      {
        user = userDto,
        token = token
      });
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserDto user)
    {
      var item = await _unitOfWork.Users.FindByEmail(user.Email);

      if (item != null)
      {

        return BadRequest("Email have already existed!!!");
      };

      User newUser = new User
      {
        Name = user.Name,
        Email = user.Email,
        Password = user.Password,
        Description = user.Description,
      };

      await _unitOfWork.Users.Add(newUser);

      await _unitOfWork.CompleteAsync();
      return new CreatedResult("user", newUser);
    }
  }
}