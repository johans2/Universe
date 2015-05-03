using UnityEngine;
using System.Collections;

namespace Universe.Game
{ 

    public class GameConstants : IGameConstants 
    {
        public float ZoneSize
        {
            get { return 100f; }
        }


        public float SnapBackWorldDistance
        {
            get { return 1000f; }
        }
    }
}