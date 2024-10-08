using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Models.Exceptions;
using Models;
using Microsoft.AspNetCore.Mvc;
namespace Services.middlewares
{
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public HandleExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) {
            try
            {
                // Call the next delegate/middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Set a generic response status code and message
            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case NotFoundException:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound; break;
                    }
                default:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    }
            }
            // Log the exception (you can replace this with your logging mechanism)
            Console.WriteLine($"Exception: {exception.Message}");

            // Create a standard error response (you can modify this as per your needs)
            var response = new ApiResult<IActionResult>();
            response.Failed(context.Response.StatusCode, exception.Message);

            // Serialize the response to JSON and return it
            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
