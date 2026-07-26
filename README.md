### initial thoughts

Each robot is processed sequentially, i.e., finishes executing the robot instructions before the next robot
begins execution. Simple for loop can be used - NO parallel or async 

Decide between storing map and pathway data or just calculating end result - for current task seems appropriate to only make path calculation (no store route / reverse route functionality) - only scented indexes to be stored between rover runs

scent can only be on 0th or nth elements of x or y array -- possible obstructions or pits within rectangle in future (possibly different square types)

### Time Constraint 

Did not have enough time to expand beyond working application including unfortunately unit tests. However I wrote the app using appropriate patterns (Factory and Stratergy) to an interface thus 
making mocking significantly easier for unit tests, whilst adhering to SOLID design especially the Open/Closed Principle and Single responsiblity

### Run Instructions 

For easiest readability of results please use the input.txt file to add various inputs (one at a time) and run  Get-Content input.txt | dotnet run 