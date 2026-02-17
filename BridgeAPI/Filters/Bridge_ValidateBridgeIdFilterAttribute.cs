using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class Bridge_ValidateBridgeIdFilterAttribute : ActionFilterAttribute
{
  private readonly IBridgeService _bridgeService;

  public Bridge_ValidateBridgeIdFilterAttribute(IBridgeService service)
  {
    _bridgeService = service;
  }
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    base.OnActionExecuting(context);
    int? bridgeId = context.ActionArguments["id"] as int?;

    if (bridgeId.HasValue)
    {
      if (bridgeId.Value <= 0)
      {
        context.ModelState.AddModelError("BridgeId", "BridgeId is invalid");
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
          Status = StatusCodes.Status400BadRequest
        };
        context.Result = new BadRequestObjectResult(problemDetails);
      }
      else if (!_bridgeService.BridgeExists(bridgeId.Value))
      {
        context.ModelState.AddModelError("BridgeId", "Bridge doesn't exist");
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
          Status = StatusCodes.Status404NotFound
        };
        context.Result = new NotFoundObjectResult(problemDetails);
      }
    }
  }
}