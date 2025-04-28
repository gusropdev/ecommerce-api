namespace RO.DevTest.Domain.Exception;

public class ErrorResponse
{
    public string Message { get; set; }
    public List<string> Errors { get; set; } = [];
    public int StatusCode { get; set; }

    public ErrorResponse(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public ErrorResponse(string message, List<string> errors, int statusCode)
    {
        Message = message;
        Errors = errors;
        StatusCode = statusCode;
    }
}