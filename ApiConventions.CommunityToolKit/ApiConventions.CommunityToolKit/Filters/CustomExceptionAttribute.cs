using ApiConventions.CommunityToolKit.ObjectResults;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ApiConventions.CommunityToolKit.Filters
{
    public class CustomException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            //处理各种异常

            context.ExceptionHandled = true;
            context.Result = new CustomExceptionResult((int)status, context.Exception);
        }
        
    }
}
