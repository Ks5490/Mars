namespace MarsRover.Models.Commands
{
    public interface IRoverCommandFactory
    {
        IRoverCommand GetCommand(char instruction);
    }
}