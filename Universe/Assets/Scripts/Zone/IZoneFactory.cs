using System;

namespace Universe.Game
{
    public interface IZoneFactory
    {
        IZone CreateZone(int coordX, int coordY);
    }
}
