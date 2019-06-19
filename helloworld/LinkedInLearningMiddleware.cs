using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace helloworld
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LinkedInLearningMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LinkedInLearningMiddleware> logger;
        private readonly IConfiguration configuration;

        public LinkedInLearningMiddleware(RequestDelegate next, ILogger<LinkedInLearningMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            this.logger = logger;
            this.configuration = configuration;
        }

        public Task Invoke(HttpContext httpContext)
        {
            logger?.LogInformation(configuration["mensaje"]);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LinkedInLearningMiddlewareExtensions
    {
        public static IApplicationBuilder UseLinkedInLearningMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LinkedInLearningMiddleware>();
        }
    }
}
