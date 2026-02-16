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
  public string CreateBridge(Bridge bridge)
  {
    return $"Creating a bridge with {bridge.BridgeId}, {bridge.WeightLimitTons}, {bridge.HeightInFeet}";
  }

  [HttpPut("{id}")]
  public string UpdateBridge(int id)
  {
    return $"Updating bridge id {id}";
  }

  [HttpDelete("{id}")]
  public string DeleteBridge(int id)
  {
    return $"Deleting bridge id {id}";
  }
}