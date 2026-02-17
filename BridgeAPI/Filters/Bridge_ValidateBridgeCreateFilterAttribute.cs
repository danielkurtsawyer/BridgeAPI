using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class Bridge_ValidateBridgeCreateFilterAttribute : ActionFilterAttribute
{
  private readonly IBridgeRepository _bridgeRepository;

  public Bridge_ValidateBridgeCreateFilterAttribute(IBridgeRepository repository)
  {
    _bridgeRepository = repository;
  }
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    base.OnActionExecuting(context);
    var bridge = context.ActionArguments["bridge"] as Bridge;

    if (bridge == null)
    {
      context.ModelState.AddModelError("Bridge", "Bridge object is null");
      var problemDetails = new ValidationProblemDetails(context.ModelState)
      {
        Status = StatusCodes.Status400BadRequest
      };
      context.Result = new BadRequestObjectResult(problemDetails);
    }
  }
}