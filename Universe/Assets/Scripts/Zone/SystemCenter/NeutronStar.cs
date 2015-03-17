using System;

namespace PseudoRandom
{
	public class NeutronStar : ISystemCenter
	{
		public NeutronStar ()
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
				return 0.05;
			}
		}

		public int MinDistanceFromCenter {
			get {
				return 30;
			}
		}
	}
}

