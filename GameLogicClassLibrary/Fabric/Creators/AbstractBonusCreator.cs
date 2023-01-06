using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class AbstractBonusCreator.
    /// </summary>
    public abstract class AbstractBonusCreator
    {
        /// <summary>
        /// Creates the bonus.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>AbstractBonus.</returns>
        public abstract AbstractBonus CreateBonus(Vector2 position);
    }
}
