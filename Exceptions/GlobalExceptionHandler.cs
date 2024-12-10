using System.Net;
using BookStoreApi.Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace BookStoreApi.Exceptions
{

    // Classe de manipulador de exceção global implementando IExceptionHandler
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        // construtor para inicializar o logger
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        // metodo para lidar com a exceção assincrona
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Log o detalhe da exceção
            _logger.LogError(exception, "An error occurred while processing your request");

            var errorResponse = new ErrorResponse
            {
                Message = exception.Message,
                Title = exception.GetType().Name
            };

            // Determine o status code baseado na exceção
            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case NoBookFoundException:
                case BookDoesNotExistException:
                    errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            // Envia a resposta status code
            httpContext.Response.StatusCode = errorResponse.StatusCode;

            // escreve o erro no corpo da resposta JSON
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            // retorne true para indicar que a exceção foi tratada
            return true;
        }
    }
}