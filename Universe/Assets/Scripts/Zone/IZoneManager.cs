using UnityEngine;
using System.Collections;
using Universe.Game;

public interface IZoneManager 
{
    IZone GetZone(int zoneX, int zoneY);
}
