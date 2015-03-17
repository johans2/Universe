
namespace PseudoRandom
{
    public class RedDwarfStar : ISystemCenter
    {
        public RedDwarfStar() 
        { 
        }

        public int Mass { get; set; }

        public int Radius { get; set; }

        public IOrbital[] Orbitals { get; private set; }

		public double RelativeProbability {
			get {
				return 1;
			}
		}

		public int MinDistanceFromCenter {
			get {
				return 15;
			}
		}
    }
}
