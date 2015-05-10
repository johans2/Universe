using UnityEngine;
using System.Collections;
using Universe.Game;
using Universe.Core.DependencyInjection;
using System.Collections.Generic;
using Universe.Core.Collections;


public class ZoneManager : IZoneManager
{
    [Dependency] public IZoneFactory zoneFactory;

    private Dictionary<Tuple<int, int>, IZone> activeZones;
    
    public ZoneManager()
    {
        this.activeZones = new Dictionary<Tuple<int, int>, IZone>();
    }
    
    public IZone GetZone(int zoneX, int zoneY)
    {
        throw new System.NotImplementedException();
    }

    //TODO: write tests for this methos. Use NUnitHelper method for accessing this private method.
    private void OnEnterZone(int zoneX, int zoneY)
    {
        
    }

}
