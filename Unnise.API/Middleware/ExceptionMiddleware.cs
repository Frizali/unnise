using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Common.Exceptions;
using Unnise.Application.Features.Users.Exceptions;

namespace Unnise.API.Middleware
{
    public sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ConflictException ex)
            {
                await WriteProblem(context, 409, "Conflict", ex.Message);
            }
            catch (ValidationException ex)
            {
                await WriteProblem(context, 400, "Validation error", ex.Message);
            }
            catch (NotFoundException ex)
            {
                await WriteProblem(context, 404, "Not Found", ex.Message);
            }
            catch (AppException ex)
            {
                await WriteProblem(context, 400, "Bad Request", ex.Message);
            }
            catch (Exception)
            {
                await WriteProblem(
                    context,
                    500,
                    "Internal Server Error",
                    "An unexpected error occurred"
                );
            }
        }

        private static async Task WriteProblem(
            HttpContext context,
            int status,
            string title,
            string detail)
        {
            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }
    }


}
