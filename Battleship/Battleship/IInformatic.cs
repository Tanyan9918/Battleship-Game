using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Used for getting the info
    /// </summary>
    public interface IInformatic
    {
        /// <summary>
        /// Gets the info of the ship
        /// </summary>
        /// <returns>Max health, current health, dead or alive, position, length, and direction</returns>
        public string GetInfo();
    }
}
