using CliverApi.DTOs;
using System.Threading.Tasks;

namespace CliverApi.Services
{
    public interface IMailService
    {
        public Task SendRegisterMail(UserDto user, string token, bool isCreated = false);
        public Task SendForgotPasswordEmail(UserDto user, string token);
    }
}
