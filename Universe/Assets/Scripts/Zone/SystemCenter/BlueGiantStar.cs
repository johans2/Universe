using System;

namespace PseudoRandom
{
	public class BlueGiantStar : ISystemCenter
	{
		public BlueGiantStar ()
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
			get {
				return 0.3;
			}
		}

		public int MinDistanceFromCenter {
			get {
				return 30;
			}
		}
	}
}

