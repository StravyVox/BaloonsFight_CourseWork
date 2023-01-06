using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class Bullet.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBullet" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBullet" />
    public class Bullet : AbstractBullet
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="XDirection">The x direction.</param>
        public Bullet(Vector2 position, int XDirection) : base(position, XDirection)
        {
        }
    }
}
