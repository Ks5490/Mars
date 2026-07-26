namespace MarsRover.Models.Commands
{
    public class RoverCommandFactory : IRoverCommandFactory
    {
        private static readonly Dictionary<char, IRoverCommand> Commands = new()
        {
            ['L'] = new TurnLeft(),
            ['R'] = new TurnRight(),
            ['F'] = new MoveOneForward()
        };
        public IRoverCommand GetCommand(char instruction)
        {
            if (!Commands.TryGetValue(instruction, out var command))
                throw new ArgumentException("Invalid Command");

            return command;
        }
    }
}
