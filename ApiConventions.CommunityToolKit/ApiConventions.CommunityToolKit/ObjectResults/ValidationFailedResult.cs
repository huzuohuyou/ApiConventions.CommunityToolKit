using ApiConventions.CommunityToolKit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiConventions.CommunityToolKit.ObjectResults
{
    public class ValidationFailedResult : ObjectResult
    {

        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationFailedResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
        
    }
}
