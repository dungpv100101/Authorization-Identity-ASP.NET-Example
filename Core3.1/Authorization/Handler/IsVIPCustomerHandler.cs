using Core3._1.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;

namespace Core3._1.Authorization.Handler
{
    public class IsVIPCustomerHandler : AuthorizationHandler<IsAllowedToManageProductRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IsAllowedToManageProductRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == "VIP"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
