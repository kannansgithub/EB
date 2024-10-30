using EB.Domain.Exceptions;
using EB.Persistence.Exceptions;
using EB.Presentation.Shared.Exceptions;
using EB.Presentation.Shared.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace EB.Presentation.Shared.Handlers;


public class CustomExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

    public CustomExceptionHandler()
    {
        _exceptionHandlers = new()
            {
                { typeof(DomainException), HandleDomainException },
                { typeof(TokenRepositoryException), HandleTokenException },
                { typeof(ApplicationException), HandleApplicationException },
                { typeof(ApiException), HandleApiException },
                { typeof(Exception), HandleException },
            };
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
            return true;
        }
        else
        {
            await HandleException(httpContext, exception);
            return true;
        }

    }

    private async Task HandleDomainException(HttpContext httpContext, Exception ex)
    {
        var exception = (DomainException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ApiErrorResult
        {
            Code = StatusCodes.Status500InternalServerError,
            Message = $"DomainException: {ex.Message}",
            Error = new Error(ex.InnerException?.Message, ex.Source, ex.StackTrace, ex.GetType().Name)
        });
    }

    private async Task HandleTokenException(HttpContext httpContext, Exception ex)
    {
        var exception = (TokenRepositoryException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ApiErrorResult
        {
            Code = StatusCodes.Status500InternalServerError,
            Message = $"TokenException: {ex.Message}",
            Error = new Error(ex.InnerException?.Message, ex.Source, ex.StackTrace, ex.GetType().Name)
        });
    }

    private async Task HandleApplicationException(HttpContext httpContext, Exception ex)
    {
        var exception = (ApplicationException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ApiErrorResult
        {
            Code = StatusCodes.Status500InternalServerError,
            Message = $"ApplicationException: {ex.Message}",
            Error = new Error(ex.InnerException?.Message, ex.Source, ex.StackTrace, ex.GetType().Name)
        });
    }

    private async Task HandleApiException(HttpContext httpContext, Exception ex)
    {
        var exception = (ApiException)ex;

        httpContext.Response.StatusCode = exception.Code;

        await httpContext.Response.WriteAsJsonAsync(new ApiErrorResult
        {
            Code = exception.Code,
            Message = $"ApiException: {exception.Message}",
            Error = new Error(ex.InnerException?.Message, exception.Source, exception.StackTrace, exception.GetType().Name)
        });
    }

    private async Task HandleException(HttpContext httpContext, Exception ex)
    {
        var exception = ex;

        await httpContext.Response.WriteAsJsonAsync(new ApiErrorResult
        {
            Code = httpContext.Response.StatusCode != 200 ? httpContext.Response.StatusCode : StatusCodes.Status500InternalServerError,
            Message = $"Exception: {ex.Message}",
            Error = new Error(ex.InnerException?.Message, ex.Source, ex.StackTrace, ex.GetType().Name)
        });
    }
}

