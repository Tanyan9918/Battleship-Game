using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the Patrol Boat information
    /// </summary>
    public class PatrolBoat : Ship
    {
        /// <summary>
        /// Passes the Patrol Boat information
        /// </summary>
        /// <param name="position">The position it is at</param>
        /// <param name="direction">The direction the patrol boat is facing</param>
        public PatrolBoat(Coord2 position, DirectionType direction) : base(position, direction, 2)
        {

        }
    }
}
