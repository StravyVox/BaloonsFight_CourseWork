using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class HealthBonus.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonus" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonus" />
    internal class HealthBonus : AbstractBonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthBonus"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public HealthBonus(Vector2 position) : base("health", "Resources\\heart.png", position, new Vector2(0.1f, 0.1f))
        {
        }
    }
}
