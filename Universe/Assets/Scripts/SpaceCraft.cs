using UnityEngine;
using System.Collections;
using Universe.Core.Collections;
using Universe.Core.DependencyInjection;
using System;

namespace Universe.Game
{
    public class SpaceCraft : ISpaceCraft
    {
        [Dependency]
        public IGameConstants gameConstants { get; private set; }

        private Vector2 transformPosition;
        private Vector2 worldPosition;
        private Tuple<int, int> currentZone;

        public event EnterZoneDelegate EnterZone;
        public event SnapBackWorldDelegate SnapBackWorld;

        public SpaceCraft() 
        {
            this.currentZone = new Tuple<int, int>(0, 0);
        }

        public Vector2 TransformPosition
        {
            get
            {
                return this.transformPosition;
            }
            set
            {
                this.transformPosition = value;
                WorldPosition = value;
            }
        }

        public Vector2 ZonePosition
        {
            get 
            { 
                return CalculateZonePosition(gameConstants.ZoneSize, worldPosition); 
            }
        }

        public Vector2 WorldPosition
        {
            get { return worldPosition; }
            private set 
            {   
                worldPosition = value;
                Tuple<int,int> zone = CalculateCurrentZone(worldPosition);

                // Fire EnterZone event if calculated new zone differs from current one.
                if (zone.Item1 != currentZone.Item1 || zone.Item2 != currentZone.Item2)
                {
                    Debug.Log("Entered Zone: " + zone.Item1 + "," + zone.Item2);
                    if (this.EnterZone != null)
                    {
                        EnterZone(zone.Item1, zone.Item2);
                    }
                }
                
                currentZone = zone;
            }
        }

        public Tuple<int, int> CurrentZone
        {
            get 
            {
                return currentZone;
            }
        }

        private Vector2 CalculateZonePosition(float zoneSize, Vector2 worldPosition) 
        {
            throw new NotImplementedException(); 
            //return new Vector2(worldPosition.x % zoneSize, worldPosition.y % zoneSize);
        }

        private Tuple<int, int> CalculateCurrentZone(Vector2 worldPosition) 
        {
            int zoneX;
            int zoneY;

            if (WorldPosition.x > 0f)
            {
                zoneX = Mathf.FloorToInt(WorldPosition.x / gameConstants.ZoneSize);
            }
            else
            {
                zoneX = Mathf.CeilToInt(Mathf.Abs(WorldPosition.x) / gameConstants.ZoneSize) * -1;
            }

            if (WorldPosition.y > 0f)
            {
                zoneY = Mathf.FloorToInt(WorldPosition.y / gameConstants.ZoneSize);
            }
            else
            {
                zoneY = Mathf.CeilToInt(Mathf.Abs(WorldPosition.y) / gameConstants.ZoneSize) * -1;
            }

            return new Tuple<int, int>(zoneX, zoneY); 
        }
    }
}