using ecommerceweb.API.Models;
using ecommerceweb.API.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ecommerceweb.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly IList<AccountRole> _roles;
        public Authorization(params AccountRole[] roles)
        {
            _roles = roles ?? new AccountRole[] {};
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Anonymous
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymous>().Any();
            if (allowAnonymous)
            {
                return;
            }

            //Authorization
            var account = (Account)context.HttpContext.Items["Account"];
            if(account == null || _roles.Any() && !_roles.Contains(account.Role))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Error",
                }));
            }
        }
    }
}
