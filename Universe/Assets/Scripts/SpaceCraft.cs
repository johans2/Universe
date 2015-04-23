using UnityEngine;
using System.Collections;
using Universe.Core.Collections;
using Universe.Core.DependencyInjection;

namespace Universe.Game
{
    public class SpaceCraft : ISpaceCraft
    {
        [Dependency]
        private IGameConstants gameConstants;

        private Vector2 transformPosition;

        public SpaceCraft() 
        {    

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
            }
        }

        public Vector2 ZonePosition
        {
            get { throw new System.NotImplementedException(); }
        }

        public Vector2 WorldPosition
        {
            get { throw new System.NotImplementedException(); }
        }

        public Tuple<int, int> CurrentZone
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}