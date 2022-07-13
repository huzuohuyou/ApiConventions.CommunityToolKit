using ApiConventions.CommunityToolKit.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConventions.CommunityToolKit.ObjectResults
{
    public class CustomExceptionResult : ObjectResult
    {
        public CustomExceptionResult(int? code, Exception exception)
            : base(new CustomExceptionResultModel(code, exception))
        {
            StatusCode = code;
        }
    }
}
