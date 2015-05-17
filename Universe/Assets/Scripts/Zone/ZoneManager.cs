using UnityEngine;
using System.Collections;
using Universe.Game;
using Universe.Core.DependencyInjection;
using System.Collections.Generic;
using Universe.Core.Collections;
using System;


public class ZoneManager : IZoneManager
{
    [Dependency] public IZoneFactory zoneFactory;

    private List<IZone> activeZones;

    public ZoneManager()
    {
        this.activeZones = new List<IZone>();
    }
    
    public IZone GetZone(int zoneX, int zoneY)
    {
        foreach (IZone zone in activeZones)
        {
            if (zone.X == zoneX && zone.Y == zoneY)
            {
                return zone;
            }
        }
        return null;
    }

    public void OnEnterZone(Tuple<int,int> oldZoneCoords, Tuple<int,int> newZoneCoords)
    {
        List<Tuple<int, int>> zonesToCreate = new List<Tuple<int, int>>();

        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1, newZoneCoords.Item2));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 + 1, newZoneCoords.Item2));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 + 1, newZoneCoords.Item2 + 1));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1, newZoneCoords.Item2 + 1));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 - 1, newZoneCoords.Item2 + 1));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 - 1, newZoneCoords.Item2));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 - 1, newZoneCoords.Item2 - 1));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1, newZoneCoords.Item2 - 1));
        zonesToCreate.Add(new Tuple<int, int>(newZoneCoords.Item1 + 1, newZoneCoords.Item2 - 1));
        
        // Add new zones
        foreach (Tuple<int, int> coord in zonesToCreate)
        {
            // this wont work
            if (GetZone(coord.Item1, coord.Item2) == null)
            {
                IZone zone = zoneFactory.CreateZone(coord.Item1, coord.Item2);
                activeZones.Add(zone);
                InstantiateZone(zone);
            }
        }

        // Remove zones that are out of radius
        List<Tuple<int, int>> zonesToDestroy = GetZonesToDestroy(oldZoneCoords, newZoneCoords);
        foreach (Tuple<int,int> coord in zonesToDestroy)
        {
            for (int i = activeZones.Count - 1; i >= 0; i-- )
            {
                if (coord.Item1 == activeZones[i].X && coord.Item2 == activeZones[i].Y)
                {
                    activeZones.Remove(activeZones[i]);
                }
            }
        }
    }

    private List<Tuple<int,int>> GetZonesToDestroy(Tuple<int, int> oldZoneCoords, Tuple<int, int> newZoneCoords) 
    {
        List<Tuple<int, int>> returnList = new List<Tuple<int, int>>();

        // X coord has increased
        if (newZoneCoords.Item1 > oldZoneCoords.Item1)
        {
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 - 1, oldZoneCoords.Item2));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 - 1, oldZoneCoords.Item2 + 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 - 1, oldZoneCoords.Item2 - 1));
        }
        // X has decreased
        else if (newZoneCoords.Item1 < oldZoneCoords.Item1)
        {
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 + 1, oldZoneCoords.Item2));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 + 1, oldZoneCoords.Item2 + 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 + 1, oldZoneCoords.Item2 - 1));
        }
        // Y has increased
        else if (newZoneCoords.Item2 > oldZoneCoords.Item2)
        {
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1, oldZoneCoords.Item2 - 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 + 1, oldZoneCoords.Item2 - 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 - 1, oldZoneCoords.Item2 - 1));
        }
        // Y has decreased
        else if (newZoneCoords.Item2 < oldZoneCoords.Item2)
        {
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1, oldZoneCoords.Item2 + 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 + 1, oldZoneCoords.Item2 + 1));
            returnList.Add(new Tuple<int, int>(oldZoneCoords.Item1 - 1, oldZoneCoords.Item2 + 1));            
        }

        return returnList;
    }

    private void InstantiateZone(IZone zone) 
    {
        if (zone.systemCenter != null)
        {
            InstantiateSystemCenter(zone.systemCenter);            
        }
    }

    private void InstantiateSystemCenter(ISystemCenter systemCenter) 
    {
        String type = systemCenter.GetType().Name;
        GameObject gameObject = GameObject.Instantiate(Resources.Load("Prefabs/SystemCenter/" + type, typeof(GameObject))) as GameObject;
    }
}