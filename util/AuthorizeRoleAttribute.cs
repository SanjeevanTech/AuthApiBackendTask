using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _.util;
public class AuthorizeRoleAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string[] _roles;

    public AuthorizeRoleAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        // If user is not authenticated
        if (user?.Identity?.IsAuthenticated != true)
        {
            context.Result = new JsonResult(new
            {
                status = 401,
                message = "You must be logged in to access this resource."
            })
            {
                StatusCode = 401
            };
            return;
        }

    
        var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

        // If the user's role is not in the allowed list
        if (string.IsNullOrEmpty(userRole) || !_roles.Contains(userRole))
        {
            context.Result = new JsonResult(new
            {
                status = 403,
                message = "Access denied. Admins only."
            })
            {
                StatusCode = 403
            };
        }
    }
}
