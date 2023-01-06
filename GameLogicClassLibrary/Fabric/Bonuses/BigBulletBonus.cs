using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class BigBulletBonus.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonus" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonus" />
    public class BigBulletBonus : AbstractBonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BigBulletBonus"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public BigBulletBonus(Vector2 position) : base("bigbullet", "Resources\\BigBullet.png", position, new Vector2(0.1f,0.1f))
        {
        }
    }
}
