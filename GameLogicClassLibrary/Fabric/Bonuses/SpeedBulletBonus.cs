using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class SpeedBulletBonus.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBonus" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBonus" />
    public class SpeedBulletBonus:AbstractBonus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedBulletBonus"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public SpeedBulletBonus(Vector2 position) : base("speedbullet", "Resources\\Speed.png", position, new Vector2(0.1f, 0.1f))
        {

        }
    }
}
