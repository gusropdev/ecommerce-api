using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ApiException ex)
        {
            context.Response.StatusCode = (int)ex.StatusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponse(
                message: ex.Errors.FirstOrDefault() ?? "Um erro ocorreu",
                errors: ex.Errors,
                statusCode: (int)ex.StatusCode
            );

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            
            var errorResponse = new ErrorResponse(
                message: "Erro interno no servidor",
                statusCode: 500
            );

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}