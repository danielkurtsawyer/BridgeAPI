public class BridgeService : IBridgeService
{
  private readonly IBridgeRepository _bridgeRepository;
  public BridgeService(IBridgeRepository repository)
  {
    _bridgeRepository = repository;
  }

  public bool BridgeExists(int id) => _bridgeRepository.BridgeExists(id);
  public List<Bridge> GetBridges() => _bridgeRepository.GetBridges();

  public Bridge? GetBridgeById(int id) => _bridgeRepository.GetBridgeById(id);

  public Bridge AddBridge(Bridge bridge) => _bridgeRepository.AddBridge(bridge);

  public void UpdateBridge(Bridge bridge) => _bridgeRepository.UpdateBridge(bridge);

  public void DeleteBridge(int id) => _bridgeRepository.DeleteBridge(id);
}