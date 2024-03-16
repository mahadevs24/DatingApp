using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        public RequestDelegate _Next { get; }
        public ILogger<ExceptionMiddleware> _Logger { get; }
        public IHostEnvironment _Env { get; }
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this._Env = env;
            this._Logger = logger;
            this._Next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _Env.IsDevelopment()
                 ? new APIException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                 : new APIException(context.Response.StatusCode, ex.Message, "Internal server error");
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }

        }
    }
}