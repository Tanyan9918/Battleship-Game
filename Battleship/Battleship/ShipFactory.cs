using System.Text.RegularExpressions;

namespace Battleship
{
    /// <summary>
    /// Creates the ships from a file
    /// </summary>
    public class ShipFactory
    {

        /// <summary>
        /// Tried to store the expression in a string, didn't work. This stores the regex.
        /// </summary>
        private readonly Regex ShipRegex = new Regex(@"^(Carrier|Battleship|Destroyer|Submarine|Patrol Boat),\s*(\d+),\s*(h|v),\s*(\d+),\s*(\d+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// A dictionary that stores the ship type and the accurate size
        /// </summary>
        private static readonly Dictionary<string, int> ShipLengths = new()
        {
            {"Carrier", 5 },
            {"Battleship", 4 },
            {"Destroyer", 3 },
            {"Submarine", 3 },
            {"Patrol Boat", 2 }
        };

        /// <summary>
        /// Did this more than once so made a function. Extracts the ship details from the file that matches the regex
        /// </summary>
        /// <param name="match">the regex matches this</param>
        /// <returns>The ship details from the file</returns>
        private (string ShipType, int Length, string Direction, int x, int y) ExtractShipDetails(Match match)
        {
            return (
                    match.Groups[1].Value,  
                    int.Parse(match.Groups[2].Value), 
                    match.Groups[3].Value.ToLower(), 
                    int.Parse(match.Groups[4].Value),  
                    int.Parse(match.Groups[5].Value) 
            );
        }
        /// <summary>
        /// Verifies the ship string
        /// </summary>
        /// <param name="description">The string needed to be compared</param>
        /// <returns>Returns true if the regex matches otherwises return false</returns>
        public bool VerifyShipString(string description)
        {
            //Honestly had to google this cause I didn't know how to check
            Match match = ShipRegex.Match(description);
            if (!match.Success)
            {
                return false;
            }
            var (shipType, length, direction, x, y) = ExtractShipDetails(match);
            if(!ShipLengths.TryGetValue(shipType, out int expectedLength) || length != expectedLength)
            {
                return false;
            }
            if(!IsValidPosition(x, y, length, direction))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks to see if the position is valid
        /// </summary>
        /// <param name="x">The x coordinate of the ship</param>
        /// <param name="y">The y coordinate of the ship</param>
        /// <param name="length">The length of the ship</param>
        /// <param name="direction">The direction the ship is facing</param>
        /// <returns>True if the position is valid else returns false</returns>
        private bool IsValidPosition(int x, int y, int length, string direction)
        {
            if(x < 0 || y < 0 || x >= 10 || y >= 10)
            {
                return false;
            }

            if(direction == "h" && (x + length) > 10)
            {
                return false;
            }

            if (direction == "v" && (y + length) > 10)
            {
                return false;
            }
            return true; 
        }

        /// <summary>
        /// Creates a ship that matches what was recieved from the file
        /// </summary>
        /// <param name="description">The description from the file</param>
        /// <returns>The new ship from the file</returns>
        public Ship ParseShipString(string description)
        {
            if(VerifyShipString(description) == true)
            {
                Match match = ShipRegex.Match(description);
                if (!match.Success)
                {
                    throw new Exception("Does not match");
                }
                var (shipType, length, direction, x, y) = ExtractShipDetails(match);
                if (length > 5 || length < 2)
                {
                    throw new Exception("Not the right length.... Something isn't right here.");
                }
                DirectionType dir = direction == "h" ? DirectionType.Horizontal : DirectionType.Vertical;
                return shipType switch
                {
                    "Carrier" => new Carrier(new Coord2 { x = x, y = y }, dir),
                    "Battleship" => new Battleship(new Coord2 { x = x, y = y }, dir),
                    "Destroyer" => new Destroyer(new Coord2 { x = x, y = y }, dir),
                    "Submarine" => new Submarine(new Coord2 { x = x, y = y }, dir),
                    "Patrol Boat" => new PatrolBoat(new Coord2 { x = x, y = y }, dir),
                    _ => throw new Exception("That's not a boat. It has to be a shark!!")
                };
            }
            else
            {
                throw new Exception("Something wrong with the Ship's string");
            }
            
        }

        /// <summary>
        /// Takes the filepath and creates the ships by going through the other classes
        /// </summary>
        /// <param name="filePath">The filepath that the file is stored</param>
        /// <returns>An array of ships</returns>
        public Ship[] ParseShipFile(string filePath)
        {
            Ship[] ships = new Ship[0];
            try
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    string description;
                    while((description = sr.ReadLine()) != null)
                    {
                        if (description[0] == '#')
                        {

                        }
                        else
                        {
                            //got this idea with the help of ChatGPT, cause I gots stuck
                            Ship newShip = ParseShipString(description);
                            Array.Resize(ref ships, ships.Length + 1);
                            ships[ships.Length - 1] = newShip;
                        }
                    }
                }

            }
            catch
            {
                throw new Exception("File path doesn't exist");
            }
            return ships;
        }
    }
}
