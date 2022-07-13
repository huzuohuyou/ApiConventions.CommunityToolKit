using ApiConventions.CommunityToolKit.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConventions.CommunityToolKit
{
    public class CtkControllerBase: ControllerBase
    {
        [NonAction]
        public override OkObjectResult Ok( object? value)
            => new OkObjectResult(new Status200Response<object>()
            {
                Message = "OK",
                Data =value
            });
    }
}
