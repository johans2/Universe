using System;

namespace PseudoRandom
{
	public interface ISystemCenterFactory
	{
		ISystemCenter CreateSystemCenter(int seed, double distance);
	}
}

