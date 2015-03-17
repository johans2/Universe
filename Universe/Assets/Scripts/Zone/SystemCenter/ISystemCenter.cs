namespace PseudoRandom
{
    public interface ISystemCenter : IProbabilityItem
    {
        int Mass { get; }
        int Radius { get; }
        IOrbital[] Orbitals { get; }
		int MinDistanceFromCenter { get; }
    }
}
