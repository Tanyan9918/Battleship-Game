using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the Destroyer information
    /// </summary>
    public class Destroyer : Ship
    {
        /// <summary>
        /// Pass the destroyer information 
        /// </summary>
        /// <param name="position">The position the destroyer is at</param>
        /// <param name="direction">The direction the destroyer is facing</param>
        public Destroyer(Coord2 position, DirectionType direction) : base(position, direction, 3)
        {

        }
    }
}
