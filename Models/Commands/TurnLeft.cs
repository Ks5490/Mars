namespace MarsRover.Models.Commands
{
    public class TurnLeft : IRoverCommand
    {
        public void Execute(Rover rover, MarsMap marsMap)
        {
            rover.CurrentOrientation = rover.CurrentOrientation switch
            {
                Orientation.N => Orientation.W,
                Orientation.W => Orientation.S,
                Orientation.S => Orientation.E,
                Orientation.E => Orientation.N,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
