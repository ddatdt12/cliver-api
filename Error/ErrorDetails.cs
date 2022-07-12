using System.Text.Json;

namespace CliverApi.Error
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {
            StatusCode = 500;
            Message = "Server Error";
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
