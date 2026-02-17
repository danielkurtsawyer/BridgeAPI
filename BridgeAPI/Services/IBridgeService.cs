public interface IBridgeService
{
  bool BridgeExists(int id);
  List<Bridge> GetBridges();
  Bridge? GetBridgeById(int id);
  Bridge AddBridge(Bridge bridge);
  void UpdateBridge(Bridge bridge);
  void DeleteBridge(int id);
}