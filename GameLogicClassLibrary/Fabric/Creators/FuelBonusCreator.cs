using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class FuelBonusCreator.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonusCreator" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonusCreator" />
    public class FuelBonusCreator : AbstractBonusCreator
    {
        /// <summary>
        /// Creates the bonus.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>AbstractBonus.</returns>
        public override AbstractBonus CreateBonus(Vector2 position)
        {
            return new FuelBonus(position);
        }
    }
}
