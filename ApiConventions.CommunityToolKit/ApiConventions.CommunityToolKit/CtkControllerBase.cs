using ApiConventions.CommunityToolKit.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConventions.CommunityToolKit
{
    public class CtkControllerBase: ControllerBase
    {
        [NonAction]
        public override OkObjectResult Ok( object? value)
            => new OkObjectResult(new BaseResultModel()
            {
                Message = "OK",
                Result = value
            });
    }
}
