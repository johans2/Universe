namespace Universe.Game
{
    public interface IZone
    {
        ISystemCenter systemCenter { get; set; }
        int X { get; }
        int Y { get; }
    }
}
