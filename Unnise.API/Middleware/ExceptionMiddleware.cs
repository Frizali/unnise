using Unnise.Application.Common.Exceptions;

namespace Unnise.API.Middleware
{
    public sealed class ExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ConflictException ex)
            {
                await WriteProblem(context, 409, "Conflict", ex.Message, null);
            }
            catch (RequestValidationException ex)
            {
                await WriteProblem(context, 400, "Validation error", "One or more validation errors occurred.", ex.Errors);
            }
            catch (NotFoundException ex)
            {
                await WriteProblem(context, 404, "Not Found", ex.Message, null);
            }
            catch (AppException ex)
            {
                await WriteProblem(context, 400, "Bad Request", ex.Message, null);
            }
            catch (Exception)
            {
                await WriteProblem(
                    context,
                    500,
                    "Internal Server Error",
                    "An unexpected error occurred",
                    null
                );
            }
        }

        private static async Task WriteProblem(
            HttpContext context,
            int status,
            string title,
            string detail,
            IReadOnlyDictionary<string, string[]>? validationError
           )
        {
            Dictionary<string, string>? formattedErrors = new();

            if(validationError is not null)
            {
                formattedErrors = validationError
                    .ToDictionary(
                        kvp => LowercaseFirstLetter(kvp.Key),
                        kvp => kvp.Value.FirstOrDefault() ?? ""
                    );
            }

            var problem = new
            {
                Status = status,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path.Value,
                Validation = formattedErrors
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }

        public static string LowercaseFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input) || char.IsLower(input[0]))
                return input;
            return char.ToLower(input[0]) + input.Substring(1);
        }
    }
}
