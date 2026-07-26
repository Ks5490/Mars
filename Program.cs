using MarsRover.Models;
using MarsRover.Models.Commands;

    string mapsize;
    mapsize = Console.ReadLine();
    if (mapsize == null){
    Console.WriteLine("No Map Size Provided");
        return 0;
    }
    var gridParts = mapsize.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var marsMap = new MarsMap(int.Parse(gridParts[0]), int.Parse(gridParts[1]));
    var roverCommandFactory = new RoverCommandFactory();

    var initCoordinatesAndOrientation = Console.ReadLine();
    
    while(initCoordinatesAndOrientation != null)
    {
        var instructions = Console.ReadLine();
        if(instructions == null)
        {
            Console.WriteLine("NO Rover instructions");
            return 0;
        }

        var initSplit = initCoordinatesAndOrientation.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var initx = int.Parse(initSplit[0]);
        var inity = int.Parse(initSplit[1]);

        if (!Enum.TryParse<Orientation>(initSplit[2], out var initorientation))
        {
            Console.WriteLine("Invalid Starting Orientation");
            return 0;
        }

        Rover activeRover = new Rover((initx, inity), initorientation, roverCommandFactory);
        Console.WriteLine(activeRover.ExecuteInstructions(instructions, marsMap));

        // reset rover 
        initCoordinatesAndOrientation = Console.ReadLine();
    }

    return 1;
