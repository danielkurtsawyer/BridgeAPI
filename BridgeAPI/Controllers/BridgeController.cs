using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BridgeController : ControllerBase
{
  private readonly IBridgeRepository _bridgeRepository;
  public BridgeController(IBridgeRepository repository)
  {
    _bridgeRepository = repository;
  }

  [HttpGet]
  public IActionResult GetBridges()
  {
    return Ok(_bridgeRepository.GetBridges());
  }

  [HttpGet("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  public IActionResult GetBridge(int id)
  {
    return Ok(_bridgeRepository.GetBridgeById(id));
  }

  [HttpPost]
  [ServiceFilter(typeof(Bridge_ValidateBridgeCreateFilterAttribute))]
  public IActionResult CreateBridge(Bridge bridge)
  {
    _bridgeRepository.AddBridge(bridge);
    return CreatedAtAction(nameof(GetBridge), new { id = bridge.BridgeId }, bridge);
  }

  [HttpPut("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  [Bridge_ValidateBridgeUpdateFilter]
  public IActionResult UpdateBridge(int id, Bridge bridge)
  {
    _bridgeRepository.UpdateBridge(bridge);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ServiceFilter(typeof(Bridge_ValidateBridgeIdFilterAttribute))]
  public IActionResult DeleteBridge(int id)
  {
    var bridge = _bridgeRepository.GetBridgeById(id);
    _bridgeRepository.DeleteBridge(id);
    return Ok(bridge);
  }
}