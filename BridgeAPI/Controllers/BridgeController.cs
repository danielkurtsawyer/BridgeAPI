using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BridgeController : ControllerBase
{
  private readonly IBridgeService _bridgeService;
  public BridgeController(IBridgeService service)
  {
    _bridgeService = service;
  }

  [HttpGet]
  public IActionResult GetBridges()
  {
    return Ok(_bridgeService.GetBridges());
  }

  [HttpGet("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  public IActionResult GetBridge(int id)
  {
    return Ok(_bridgeService.GetBridgeById(id));
  }

  [HttpPost]
  [ServiceFilter(typeof(Bridge_ValidateBridgeCreateFilterAttribute))]
  public IActionResult CreateBridge(Bridge bridge)
  {
    _bridgeService.AddBridge(bridge);
    return CreatedAtAction(nameof(GetBridge), new { id = bridge.BridgeId }, bridge);
  }

  [HttpPut("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  [Bridge_ValidateBridgeUpdateFilter]
  public IActionResult UpdateBridge(int id, Bridge bridge)
  {
    _bridgeService.UpdateBridge(bridge);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  public IActionResult DeleteBridge(int id)
  {
    var bridge = _bridgeService.GetBridgeById(id);
    _bridgeService.DeleteBridge(id);
    return Ok(bridge);
  }
}