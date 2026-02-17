using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BridgeController : ControllerBase
{
  [HttpGet]
  public IActionResult GetBridges()
  {
    return Ok(BridgeRepository.GetBridges());
  }

  [HttpGet("{id}")]
  [Bridge_ValidateBridgeIdFilter]
  public IActionResult GetBridge(int id)
  {
    return Ok(BridgeRepository.GetBridgeById(id));
  }

  [HttpPost]
  [Bridge_ValidateBridgeCreateFilter]
  public IActionResult CreateBridge(Bridge bridge)
  {
    BridgeRepository.AddBridge(bridge);
    return CreatedAtAction(nameof(GetBridge), new { id = bridge.BridgeId }, bridge);
  }

  [HttpPut("{id}")]
  [Bridge_ValidateBridgeIdFilter]
  [Bridge_ValidateBridgeUpdateFilter]
  public IActionResult UpdateBridge(int id, Bridge bridge)
  {
    BridgeRepository.UpdateBridge(bridge);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public string DeleteBridge(int id)
  {
    return $"Deleting bridge id {id}";
  }
}