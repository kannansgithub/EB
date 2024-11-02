using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Shared.Filters;

public class ClaimBasedAuthorizationAttribute(string operationName) : ActionFilterAttribute
{
    private readonly string _operationName = operationName;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerName = context.Controller.GetType().Name.Replace("Controller", "");
        var requiredClaim = $"{controllerName}:{_operationName}";

        var user = context.HttpContext.User;
        if (!user.Claims.Any(c => c.Type == "Permission" && c.Value == requiredClaim))
        {
            context.Result = new UnauthorizedResult();
        }

        base.OnActionExecuting(context);
    }
}
