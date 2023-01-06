using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class ArmorBonus.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonus" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonus" />
    public class ArmorBonus : AbstractBonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorBonus"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public ArmorBonus(Vector2 position) : base("armor", "Resources\\shield.png", position, new Vector2(0.1f, 0.1f))
        {
        }
    }
}
