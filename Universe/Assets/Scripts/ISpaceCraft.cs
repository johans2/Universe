using System;
using UnityEngine;
using Universe.Core.Collections;

namespace Universe.Game
{
    public delegate void EnterZoneDelegate(Tuple<int,int> oldZone, Tuple<int,int> newZone);
    public delegate void SnapBackWorldDelegate();

    public interface ISpaceCraft
    {
        /// <summary>
        /// Position of the actual transform
        /// </summary>
        Vector2 TransformPosition { get; set; }

        /// <summary>
        /// Position inside the zone
        /// </summary>
        Vector2 ZonePosition { get; }

        /// <summary>
        /// Position in the world. Unaffected by SnapBackWorld.
        /// </summary>
        Vector2 WorldPosition { get; }

        /// <summary>
        /// Current zone of the spacecraft.
        /// </summary>
        Tuple<int, int> CurrentZone { get; }

        /// <summary>
        /// Fired when spacecraft enters a new zone.
        /// </summary>
        event EnterZoneDelegate EnterZone;

        /// <summary>
        /// Fired when the spacecraft has gone beyond SnapBackWorldDistance.
        /// </summary>
        event SnapBackWorldDelegate SnapBackWorld;
    } 
}
