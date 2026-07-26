namespace MarsRover.Models.Commands
{
    public interface IRoverCommand
    {
        public void Execute(Rover rover, MarsMap marsMap);
    }
}
