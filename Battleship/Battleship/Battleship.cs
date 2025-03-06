using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the Battleship information
    /// </summary>
    public class Battleship : Ship
    {
        /// <summary>
        /// Passes the Battleship information
        /// </summary>
        /// <param name="position">The position it is at</param>
        /// <param name="direction">The direction it is facing</param>
        public Battleship(Coord2 position, DirectionType direction) : base(position, direction, 4)
        {
        }
    }
}
