using Universe.Game;

namespace Universe.Core.Generation
{
    public class RockyPlanet : IOrbital
    {
        public RockyPlanet() 
        { 
        }

        public int Mass { get; private set; }

        public int Radius { get; private set; }
    }
}
