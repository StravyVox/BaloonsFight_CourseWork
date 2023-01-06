using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class FastBullet.
    /// Implements the <see cref="GameLogicClassLibrary.BulletDecorator" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.BulletDecorator" />
    public class FastBullet : BulletDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FastBullet"/> class.
        /// </summary>
        /// <param name="bulletToDecorate">The bullet to decorate.</param>
        public FastBullet(AbstractBullet bulletToDecorate) : base(bulletToDecorate)
        {
            Speed *= 2;
            Size = bulletToDecorate.Size;
            Damage = bulletToDecorate.Damage;
        }
    }
}
