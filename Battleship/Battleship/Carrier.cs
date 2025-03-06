using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the Carrier information
    /// </summary>
    public class Carrier : Ship
    {
        /// <summary>
        /// Passes the Carrier information
        /// </summary>
        /// <param name="position">The position it is in</param>
        /// <param name="direction">The direction it is facing</param>
        public Carrier(Coord2 position, DirectionType direction) : base(position, direction, 5)
        {

        }
    }
}
