using System.Text.Json;

namespace CliverApi.Error
{
  public class ApiException : Exception
  {

    public ApiException(string message = "Server Error") : base(message)
    {
      StatusCode = 500;
    }
    public ApiException(string message = "Server Error", int statusCode = 500) : base(message)
    {
      StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
    public override string ToString() => JsonSerializer.Serialize(new
    {
      message = Message,
      statusCode = StatusCode
    });

  }
}
