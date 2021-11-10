using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Shared;
using Newtonsoft.Json;

namespace BlazorProject.Server.Middlewares
{    
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;
        private readonly ILogger<CustomAuthMiddleware> logger;

        public CustomAuthMiddleware(RequestDelegate next, IConfiguration _configuration,ILogger<CustomAuthMiddleware> _logger)
        {
            _next = next; 
            configuration = _configuration;
            logger = _logger;
        }        

        public async Task Invoke(HttpContext httpContext)
        {
            bool allowAnnonymous = false;
            
            allowAnnonymous = httpContext.Request.Path.Value.ToLower().Contains("/api/user/login") || 
                httpContext.Request.Path.Value.ToLower().Contains("/api/user/register") ||                
                !httpContext.Request.Path.Value.ToLower().Contains("/api");
            if(!allowAnnonymous)
            {
                logger.LogInformation($"{httpContext.Request.Path.Value} | {httpContext.Request.Method} | {httpContext.Request.HttpContext.Connection.RemoteIpAddress}");

                if (!httpContext.Request.Headers.TryGetValue("Authorization", out var authorization))
                {
                    //httpContext.Response.StatusCode = 401;
                    //await httpContext.Response.WriteAsync("Unauthorised");
                    //return;

                    ResponseDTO rdto = new ResponseDTO();
                    rdto.StatusCode = 401;
                    rdto.Message = "Unauthorised";
                    rdto.Data = null;
                    string resp = JsonConvert.SerializeObject(rdto);

                    await httpContext.Response.WriteAsync(resp);
                }
                
                string[] auth = authorization.ToString().Split(" ");

                if(auth.Length > 1)
                {
                    if (!string.IsNullOrWhiteSpace(auth[1]))
                    {
                        var obj = Utility.VerifyToken(auth[1],
                            configuration.GetValue(typeof(string), "TOKEN_SECRET").ToString());

                        if (obj.Item1 == "403")
                        {
                            //httpContext.Response.StatusCode = 403;
                            //await httpContext.Response.WriteAsync(obj.Item2.ToString());
                            //return;

                            ResponseDTO rdto = new ResponseDTO();
                            rdto.StatusCode = 403;
                            rdto.Message = obj.Item2.ToString();
                            rdto.Data = null;
                            string resp = JsonConvert.SerializeObject(rdto);

                            await httpContext.Response.WriteAsync(resp);
                            return;
                        }
                        else
                        {
                            httpContext.Request.Headers.Add("userid", obj.Item3["claim1"].ToString());
                            httpContext.Request.Headers.Add("userfullname", obj.Item3["claim2"].ToString());
                            httpContext.Request.Headers.Add("role", obj.Item3["claim3"].ToString());
                        }
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Unauthorised");
                    return;
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}
