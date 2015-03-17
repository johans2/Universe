using System;

namespace PseudoRandom
{
	public class YellowStar : ISystemCenter
	{
		public YellowStar ()
		{
		}

		public int Mass {
			get {
				throw new NotImplementedException ();
			}
		}

		public int Radius {
			get {
				throw new NotImplementedException ();
			}
		}

		public IOrbital[] Orbitals {
			get {
				throw new NotImplementedException ();
			}
		}

		public double RelativeProbability {
			get 
			{
				return 1;
			}
		}

		public int MinDistanceFromCenter {
			get {
				return 2;
			}
		}
	}
}

