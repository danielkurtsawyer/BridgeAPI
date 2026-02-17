public class BridgeRepository : IBridgeRepository
{
  private List<Bridge> _bridges = new List<Bridge>()
  {
    new Bridge {
            BridgeId = 1,
            BridgeName = "Liberty Avenue Overpass",
            HeightInFeet = 13.5,
            WeightLimitTons = 20
        },
        new Bridge
        {
            BridgeId = 2,
            BridgeName = "Riverfront Industrial Bridge",
            HeightInFeet = 15.0,
            WeightLimitTons = 35
        },
        new Bridge
        {
            BridgeId = 3,
            BridgeName = "Downtown Rail Crossing",
            HeightInFeet = 12.0,
            WeightLimitTons = 18
        },
        new Bridge
        {
            BridgeId = 4,
            BridgeName = "North Hills Connector",
            HeightInFeet = 14.2,
            WeightLimitTons = 25
        },
        new Bridge
        {
            BridgeId = 5,
            BridgeName = "Steel Valley Freight Route",
            HeightInFeet = 16.0,
            WeightLimitTons = 40
        }
  };

  public bool BridgeExists(int id)
  {
    return _bridges.Any(x => x.BridgeId == id);
  }

  public List<Bridge> GetBridges()
  {
    return _bridges;
  }

  public Bridge? GetBridgeById(int id)
  {
    return _bridges.FirstOrDefault(x => x.BridgeId == id);
  }

  public Bridge AddBridge(Bridge bridge)
  {
    bridge.BridgeId = _bridges.Max(x => x.BridgeId) + 1;
    _bridges.Add(bridge);
    return bridge;
  }

  public void UpdateBridge(Bridge bridge)
  {
    var bridgeToUpdate = _bridges.First(x => x.BridgeId == bridge.BridgeId);
    bridgeToUpdate.BridgeName = bridge.BridgeName;
    bridgeToUpdate.HeightInFeet = bridge.HeightInFeet;
    bridgeToUpdate.WeightLimitTons = bridge.WeightLimitTons;
  }

  public void DeleteBridge(int id)
  {
    var bridge = GetBridgeById(id);
    if (bridge != null)
    {
      _bridges.Remove(bridge);
    }
  }
}