using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class Bridge_ValidateBridgeUpdateFilterAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    base.OnActionExecuting(context);
    var id = context.ActionArguments["id"] as int?;
    var bridge = context.ActionArguments["bridge"] as Bridge;

    if (id.HasValue && bridge != null && id != bridge.BridgeId)
    {
      context.ModelState.AddModelError("BridgeId", "BridgeId does not match id");
      var problemDetails = new ValidationProblemDetails(context.ModelState)
      {
        Status = StatusCodes.Status400BadRequest
      };
      context.Result = new BadRequestObjectResult(problemDetails);
    }
  }
}