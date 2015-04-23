using UnityEngine;
using Universe.Core.Collections;


namespace Universe.Game
{
    public interface ISpaceCraft
    {
        Vector2 TransformPosition { get; set; }

        Vector2 ZonePosition { get; }

        Vector2 WorldPosition { get; }

        Tuple<int, int> CurrentZone { get; }

        // Event EnterZone
    } 
}
