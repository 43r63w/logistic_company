using Application.Configuring.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Net;


namespace Backend.Middlware
{
    public class ExceptionHandlerMiddlware
    {
        private RequestDelegate _next;
        private ProblemDetailsFactory _problemDetailsFactory;

        public ExceptionHandlerMiddlware(RequestDelegate next,
            ProblemDetailsFactory problemDetailsFactory)
        {
            _next = next;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var problem = new ProblemDetails
            {
                Instance = context.Request.Path,
                Detail = exception?.Message,
                Status = (int)HttpStatusCode.InternalServerError
            };

            switch (exception)
            {
                case BadRequestException badRequestException:
                    problem.Status = (int)HttpStatusCode.BadRequest;
                    foreach (var infoAboutProblem in badRequestException.Errors)
                    {
                        problem.Extensions.Add(infoAboutProblem.Key, infoAboutProblem.Value);
                    }
                    break;
                case NotFoundException NotFound:
                    problem.Status = (int)HttpStatusCode.NotFound;
                    break;
                case ConflictException conflictException:
                    problem.Status = (int)HttpStatusCode.Conflict;
                    break;
                default:
                    problem.Status = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            if (_problemDetailsFactory != null)
            {
                var problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext: context, statusCode: problem.Status);
                problem.Title = problemDetails.Title;
                problem.Type = problemDetails.Type;
            }


            var result = new ObjectResult(problem)
            {
                StatusCode = problem.Status,
            };


            var response = JsonConvert.SerializeObject(result.Value);
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(response);
        }


    }
}
