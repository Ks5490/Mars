using MarsRover.Models.Commands;

namespace MarsRover.Models
{
    public class Rover((int,int) initCoordinates, Orientation initOrientation, IRoverCommandFactory roverCommandFactory)
    {   
        public Orientation CurrentOrientation { get; set; } = initOrientation;
        public (int, int) CurrentCoordinates { get; set; } = initCoordinates;
        public bool IsFallen { get; set; }

        public string ExecuteInstructions(string instructions, MarsMap map)
        {
            foreach(char instruction in instructions)
            {
                if (IsFallen) break;
                IRoverCommand roverCommand = roverCommandFactory.GetCommand(instruction);
                roverCommand.Execute(this, map);
            }
            (int currentx, int currenty) = CurrentCoordinates;
            return string.Format(currentx.ToString() + " " + currenty.ToString() + " " + CurrentOrientation.ToString() + (IsFallen ? " LOST" : ""));
        }
    }
}
  