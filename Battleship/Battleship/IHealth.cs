using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Handles the health of the ships
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        /// Gets the max health of the ship
        /// </summary>
        /// <returns>The max health</returns>
        public int GetMaxHealth();

        /// <summary>
        /// Gets the current health of the ship
        /// </summary>
        /// <returns></returns>
        public int GetCurrentHealth();

        /// <summary>
        /// Checks if the ship is dead
        /// </summary>
        /// <returns>f the ship is alive or dead</returns>
        public bool IsDead();
    }
}
