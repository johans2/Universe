using UnityEngine;
using System.Collections;
using Universe.Game;
using Universe.Core.Collections;

public interface IZoneManager 
{
    /// <summary>
    /// Get one of the active zones by X and Y coordinate
    /// </summary>
    IZone GetZone(int zoneX, int zoneY);

    /// <summary>
    /// Refactor...should not be in public interface
    /// </summary>
    void OnEnterZone(Tuple<int, int> coordX, Tuple<int, int> coordY);
}
