using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class ArmorBonusCreator.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonusCreator" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonusCreator" />
    public class ArmorBonusCreator : AbstractBonusCreator
    {
        /// <summary>
        /// Creates the bonus.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>AbstractBonus.</returns>
        public override AbstractBonus CreateBonus(Vector2 position)
        {
            return new ArmorBonus(position);
        }
    }
}
