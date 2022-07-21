using AutoMapper;
using CliverApi.Attributes;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Error;
using CliverApi.Models;
using CliverApi.Services;
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
        private readonly IMailService _mailService;
        private static IDictionary<string, Token> TokenAccountMap = new Dictionary<string, Token>();

        public AuthController(ILogger<AuthController> logger, IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            var user = await _unitOfWork.Users.FindUserByEmailAndPassword(loginUser.Email, loginUser.Password);

            if (user == null)
            {
                //throw new HttpResponseException("Not found", 404);
                return NotFound(
                    new HttpResponseException("Email or password is wrong")
                    { StatusCode = 404 })
                    ;
            }

            string token = _unitOfWork.Auth.GenerateToken(user);
            UserDto userDto = _mapper.Map<UserDto>(user);

            return Ok(new
            {
                data = userDto,
                token = token
            });
        }

        [HttpGet]
        [Route("verify")]
        [Protect]
        public IActionResult Verify()
        {
            var user = HttpContext.Items["User"] as User;
            return Ok(new
            {
                data = user
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            var item = await _unitOfWork.Users.FindByEmail(user.Email);
            if (item != null)
            {
                return BadRequest(new HttpResponseException("Email have already existed!!!", 400));
            };

            var code = new Token { Value = GenerateCode(), ExpiredAt = DateTime.Now.AddMinutes(15), User = user };
            TokenAccountMap.Add(user.Email, code);
            await _mailService.SendRegisterMail(new UserDto { Email = user.Email }, code.Value);
            return Ok(new
            {
                message = "Send email verification successfully"
            });
        }

        [HttpPost]
        [Route("verify-account")]
        public async Task<IActionResult> VerifyEmailToken(TokenVerificationDto data)
        {
            Token token;
            if (!TokenAccountMap.TryGetValue(data.Email, out token!) || data.Code != token.Value || token.ExpiredAt < DateTime.Now)
            {
                return BadRequest(new
                {
                    message = "Code is wrong or expired!"
                });
            }
            var registerData = token.User;

            User newUser = new User
            {
                Name = registerData.Name,
                Email = registerData.Email,
                Password = registerData.Password,
                IsActived = true
            };
            await _unitOfWork.Users.Add(newUser);
            await _unitOfWork.CompleteAsync();
            UserDto returnUser = _mapper.Map<UserDto>(newUser);
            return Ok(new
            {
                message = "Verify account successfully!",
                data = returnUser
            });

        }
        private string GenerateCode()
        {
            return new Random().Next(1000, 9999).ToString("D4");
        }
    }
}