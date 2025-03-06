namespace Battleship
{
    /// <summary>
    /// Creates basic functions for the different ships
    /// </summary>
    public abstract class Ship : IHealth, IInformatic
    {
        /// <summary>
        /// The position of the ship
        /// </summary>
        private Coord2 Position;

        /// <summary>
        /// The length of the ship
        /// </summary>
        private byte Length;

        /// <summary>
        /// The direction the ship is in
        /// </summary>
        private DirectionType Direction;

        /// <summary>
        /// The points at where the ships are
        /// </summary>
        private Coord2[] Points;

        /// <summary>
        /// Where the damaged points of the ships are at
        /// </summary>
        private List<Coord2> DamagedPoints;

        /// <summary>
        /// A ship has to have these
        /// </summary>
        /// <param name="position">The position of the ship</param>
        /// <param name="direction">The direction it is facing</param>
        /// <param name="length">The length of the ship</param>
        public Ship(Coord2 position, DirectionType direction, byte length)
        {
            Position = position;
            Length = length;
            Direction = direction;
            DamagedPoints = new List<Coord2>();
            Points = new Coord2[6];
            GeneratePoints();
        }

        /// <summary>
        /// Generates the points at which the ship is at
        /// </summary>
        private void GeneratePoints()
        {
            for(int i = 0; i < Length; i++)
            {
                if(Direction == DirectionType.Horizontal)
                {
                    Points[i] = new Coord2 { x = Position.x, y = Position.y + i};
                }
                else if(Direction == DirectionType.Vertical) 
                {
                    Points[i] = new Coord2 { x = Position.x + i, y = Position.y};
                }
                else
                {
                    throw new Exception("Not facing a direction.");
                }
            }
        }

        /// <summary>
        /// Gets the current health of the ship 
        /// </summary>
        /// <returns>The current health of the ship</returns>
        public int GetCurrentHealth()
        {
            return Length - DamagedPoints.Count;
        }

        /// <summary>
        /// Gets the basic info of the ship
        /// </summary>
        /// <returns>The info of the ship</returns>
        public string GetInfo()
        {
            return $"{GetName()} - Dead? {IsDead()}, Health: {GetCurrentHealth()}/{GetMaxHealth()}, Position: ({Position.x}, {Position.y}), Direction: {Direction}, Length: {Length}";
        }

        /// <summary>
        /// Gets the max health of the ship
        /// </summary>
        /// <returns>Length(max health)</returns>
        public int GetMaxHealth()
        {
            return Length;
        }

        /// <summary>
        /// Checks if the ship is dead
        /// </summary>
        /// <returns>Returns true if the health is 0 else returns false</returns>
        public bool IsDead()
        {
            if (GetCurrentHealth() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the point is hit
        /// </summary>
        /// <param name="point">The point in question</param>
        /// <returns>If the point hits or not</returns>
        public bool CheckIfHit(Coord2 point)
        {
            for(var i = 0; i < Points.Length; i++)
            {
                if(Points[i].x == point.x && Points[i].y == point.y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If the the point hits and isn't already damaged the point then is damaged
        /// </summary>
        /// <param name="point">The point that needs to be checked</param>
        public void TakeDamage(Coord2 point)
        {
            if(CheckIfHit(point) && !DamagedPoints.Contains(point))
            {
                DamagedPoints.Add(point);
            }
        }

        /// <summary>
        /// Gets the name of the ship
        /// </summary>
        /// <returns>The name of the ship/class</returns>
        public string GetName()
        {
            //Honestly didn't know how to do this found it on stack overflow
            return this.GetType().Name;
        }
    }
}
