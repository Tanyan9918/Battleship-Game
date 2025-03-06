using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the submarine information
    /// </summary>
    public class Submarine : Ship
    {
        /// <summary>
        /// Passes the submarine information
        /// </summary>
        /// <param name="position">The position it is at</param>
        /// <param name="direction">The direction it is facing</param>
        public Submarine(Coord2 position, DirectionType direction) : base(position, direction, 2)
        {

        }
    }
}
