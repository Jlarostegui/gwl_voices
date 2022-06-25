using gwl_voices.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace gwl_voices.API.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class AuthorizeAttribute : Attribute, IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ILoginService loginService = context.HttpContext.RequestServices.GetService<ILoginService>();
            string token = context.HttpContext.Request.Headers.Authorization;
            bool access = loginService.ValidateToken(token);
            if (!access)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
         
        }
    }
}
