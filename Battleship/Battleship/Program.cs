namespace Battleship
{
    internal class Program
    {
        /// <summary>
        /// Handles the display and user input
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*The user should have the ability to provide a file of ships to parse as a command line argument for the
            program.
            a. If a command line argument is provided, then parse that file.
            b. If a command line argument is NOT provided, then the program shall ask the user for a file path,
            then parse that file.
            c. If the file does not exists, cannot be opened, or otherwise, then the program shall exit
             */
            Ship[] aliveShips = null;
            ShipFactory shipFactory = new ShipFactory();
            Console.WriteLine("Hello and welcome to the game of Battle Ship.");
            Console.WriteLine("The rules are simple, you have to sink all the boats to win.");
            Console.WriteLine("These boats are and their lengths:");
            Console.WriteLine();
            Console.WriteLine("Carrier, 5");
            Console.WriteLine("Battleship, 4");
            Console.WriteLine("Destroyer, 3");
            Console.WriteLine("Submarine, 3");
            Console.WriteLine("Patrol Boat, 2");
            Console.WriteLine();
            Console.WriteLine("What is the file you are wanting to use?");
            try
            {
                string filePath = Console.ReadLine();
                aliveShips = shipFactory.ParseShipFile(filePath);
            }
            catch
            {
                throw new Exception("File Path Doesn't exist");
            }

            //The next part would be to make a game loop, would use a while loop
            //The while loop would run off an Array of live ships. 
            //Once the boats are all removed cause they are dead the while loop would end
            //Has to take in the Coord2 from the console.readline and other info
            //If exit is typed then remove all boats, anything else besides the Coord2s
            //then respond with "Command not recognized."
            Console.WriteLine("Type info for the info for the ships, type x,y for the points you are attacking, and/or type exit to exit");
            while (aliveShips.Any(ship => !ship.IsDead()))
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                string response;
                response = Console.ReadLine();
                string[] parts = response.Split(',');
                if (response.ToLower() == "info")
                {
                    Console.WriteLine("Ship statuses:");
                    for (int i = 0; i < aliveShips.Length; i++)
                    {
                        Console.WriteLine(aliveShips[i].GetInfo());
                    }
                }
                else if (response.ToLower() == "exit")
                {
                    aliveShips = Array.Empty<Ship>();
                    Console.WriteLine("Game exited.");
                    break;
                }
                else 
                if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    Coord2 attack = new Coord2 { x = x, y = y };
                    Console.WriteLine($"Attacking: ({x},{y})");
                    for(int i = 0; i < aliveShips.Length; i++)
                    {
                        if (aliveShips[i].CheckIfHit(attack))
                        {
                            Console.WriteLine("Hit!");
                            aliveShips[i].TakeDamage(attack);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Command not recognized");
                }

                //ChatGPT helped with this originally had a for loop, but it kept breaking
                aliveShips = aliveShips.Where(ship => !ship.IsDead()).ToArray();
            }
            Console.WriteLine("All ships have sunk. You win!");
        }
    }
}
