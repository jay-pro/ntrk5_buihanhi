using ecommerceweb.API.Helpers;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Services;
using Microsoft.Extensions.Options;

namespace ecommerceweb.API.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IAuthenticateService service, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = jwtUtils.ValidateJwtToken(token);
            if(accountId != null)
            {
                context.Items["Account"] = service.GetById(accountId.Value);
            }
            await _next(context);
        }
    }
}
