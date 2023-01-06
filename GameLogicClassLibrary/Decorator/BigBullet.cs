using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class BigBullet.
    /// Implements the <see cref="GameLogicClassLibrary.BulletDecorator" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.BulletDecorator" />
    public class BigBullet : BulletDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BigBullet"/> class.
        /// </summary>
        /// <param name="bulletToDecorate">The bullet to decorate.</param>
        public BigBullet(AbstractBullet bulletToDecorate) : base(bulletToDecorate)
        {
            Damage += 1   ;
            Size *= 2;
            Speed = bulletToDecorate.Speed;
        }
    }
}
