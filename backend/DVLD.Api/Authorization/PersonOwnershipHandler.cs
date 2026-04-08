using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DVLD.Api.Authorization
{
    public class PersonOwnershipHandler : AuthorizationHandler<PersonOwnershipRequirement,int>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            PersonOwnershipRequirement requirement,
            int requestedPersonId)
        {
            if (context.User.IsInRole("Admin") ||
                context.User.IsInRole("Employee"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var loggedInPersonIdString = context.User.FindFirstValue("PersonId");

            if (int.TryParse(loggedInPersonIdString, out int loggedInPersonId))
            {
                if (loggedInPersonId == requestedPersonId)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;

        }

    }
}
