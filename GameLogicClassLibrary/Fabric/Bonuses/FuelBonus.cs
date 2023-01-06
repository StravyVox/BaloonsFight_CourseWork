using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class FuelBonus.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonus" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonus" />
    public class FuelBonus: AbstractBonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuelBonus"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public FuelBonus(Vector2 position) : base("fuel", "Resources\\fuel.png", position, new Vector2(0.1f, 0.1f))
        {

        }
    }
}
