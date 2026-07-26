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


### technical walkthrough 

First technical desicion was to split the "marsmap" model away from the "rover". If the scope of the application was certianly limited to the current description it would probably be understandable 
to keep the mapping elements of the logic within the rover class. However seperating them better alligns with the Single Responsilbity Principle - the rover class doesnt store the "scented"
areas - which could expand to include other behaviors e.g. volcano - deletes all rover history  or water - requires two "F" movements in a row in same orientation to get out ect.

Use of stratergy pattern and factory to select rover command - easy point of access to add in additional functionality e.g. Move backwards / move 3 forward ect (maybe reflection to use third party uploads) 


### unit test stratergy 

The MarsMap and individual commands have no dependencies and can easily be tested independantly with a combination of various scenarios:
Map - initalize - add scented  then Assert the case
Move Left and Move Right can be exhuasted - all scenarios 
Move forward - three scenarios - move forward ok / move forward and fall off / move forward on scented and ignore

Command Factory - only testing mappings not logic within as thats executed in the above mentioned tests
Rover class - use mocking to simulate commands and factory and test is rover class is calling right commands and returns properly formated input

WOuld also add in an intergration test which runs the classes together - strengths the testing of commuinication between classes (particularly useful for the scented passing between rovers)