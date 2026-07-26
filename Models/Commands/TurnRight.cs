namespace MarsRover.Models.Commands
{
    public class TurnRight : IRoverCommand 
    {
        public void Execute(Rover rover, MarsMap marsMap)
        {
            rover.CurrentOrientation = rover.CurrentOrientation switch
            {
                Orientation.N => Orientation.E,
                Orientation.E => Orientation.S,
                Orientation.S => Orientation.W,
                Orientation.W => Orientation.N,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
