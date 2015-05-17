
namespace Universe.Game
{
    public class Zone : IZone
    {
        public Zone(int zoneX, int zoneY)
        {
            X = zoneX;
            Y = zoneY;
        }

        public ISystemCenter systemCenter { get; set; }

        public int X { get; private set; }

        public int Y { get; private set; }

    }
}
