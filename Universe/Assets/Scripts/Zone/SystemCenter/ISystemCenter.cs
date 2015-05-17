using UnityEngine;
using Universe.Core.Generation;

namespace Universe.Game
{
    public interface ISystemCenter : IProbabilityItem
    {
        //GameObject GameObject { get; }

        int Mass { get; }
        
        int Radius { get; }
        
        IOrbital[] Orbitals { get; }
		
        int MinDistanceFromCenter { get; }
    }
}
