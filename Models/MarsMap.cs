namespace MarsRover.Models
{
    public class MarsMap(int width, int height)
    {
        public int Width { get; } = width;
        public int Height { get; } = height;
        public HashSet<(int, int)> ScentedCoordinates { get; } = new();

        public bool IsScented(int x, int y)
        {
            return ScentedCoordinates.Contains((x, y));
        }

        public void AddScent(int x, int y)
        {
            ScentedCoordinates.Add((x, y));
        }
    }
}
