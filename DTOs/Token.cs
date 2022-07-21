namespace CliverApi.DTOs
{
    public class Token
    {
        public string Value { get; set; } = null!;
        public DateTime ExpiredAt;
        public RegisterUserDto User = null!;

    }
}
