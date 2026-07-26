namespace MarsRover.Models.Commands
{
    public class MoveOneForward : IRoverCommand
    {
        public void Execute(Rover rover, MarsMap marsMap)
        {
            (int movex, int movey) = rover.CurrentOrientation switch
            {
                Orientation.N => (0, 1),
                Orientation.E => (1, 0),
                Orientation.S => (0, -1),
                Orientation.W => (-1, 0),
                _ => throw new NotImplementedException()
            };

            (int currentx, int currenty) = rover.CurrentCoordinates;
            (int possiblex, int possibley) = (currentx + movex, currenty + movey);

            if(possiblex < 0 || possiblex > marsMap.Width || possibley < 0 || possibley > marsMap.Height)
            {
                if (marsMap.IsScented(currentx, currenty)){
                    return;
                }
                marsMap.AddScent(currentx, currenty);
                rover.IsFallen = true;
                return;
            }
            rover.CurrentCoordinates = (possiblex, possibley);
        }
    }
}
