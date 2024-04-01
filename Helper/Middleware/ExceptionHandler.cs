using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Helper.LogManager1;

namespace Tooth_Booth_API.Helper.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        ILoggerManager loggerManager;
        public ExceptionHandler(RequestDelegate next,ILoggerManager loggermanager)
        {
            this.next = next;
            this.loggerManager = loggermanager;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode= 500;
                await context.Response.WriteAsync(Error.someThingWrong);
                loggerManager.LogError(ex.ToString());
            }
        }
    }
}
