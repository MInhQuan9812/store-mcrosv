using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Net;

namespace ApiGateWays.Middleware
{
    public class AuthorizationResultHandler: IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler _handler;

        public AuthorizationResultHandler()
        {
            _handler = new AuthorizationMiddlewareResultHandler();
        }

        public Task HandleAsync(RequestDelegate next,HttpContext context,AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if(authorizeResult.Challenged)
            {
                context.Response.StatusCode=(int)HttpStatusCode.Unauthorized;
                return Task.CompletedTask;
            }

            if (!authorizeResult.Forbidden)
            {
                return _handler.HandleAsync(next,context, policy, authorizeResult);
            }
            context.Response.StatusCode=(int)HttpStatusCode.Forbidden;

            return Task.CompletedTask;
        }

    }
}
