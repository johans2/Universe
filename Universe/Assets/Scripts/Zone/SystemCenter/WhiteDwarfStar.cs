
namespace PseudoRandom
{
    public class WhiteDwarfStar : ISystemCenter
    {
        public int Mass
        {
            get { throw new System.NotImplementedException(); }
        }

        public int Radius
        {
            get { throw new System.NotImplementedException(); }
        }

        public IOrbital[] Orbitals
        {
            get { throw new System.NotImplementedException(); }
        }

		public double RelativeProbability {
			get {
				return 0.8;
			}
		}

		public int MinDistanceFromCenter {
			get {
				return 5;
			}
		}
    }
}
