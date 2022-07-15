using gwl_voices.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace gwl_voices.API.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class AuthorizeAttribute : Attribute

    {
    }
}

