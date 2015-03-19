using System;

namespace Universe.Game
{
	public interface ISystemCenterFactory
	{
		ISystemCenter CreateSystemCenter(int seed, double distance);
	}
}

