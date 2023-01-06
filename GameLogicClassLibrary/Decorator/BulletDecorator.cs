using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class BulletDecorator.
    /// Implements the <see cref="GameLogicClassLibrary.AbstractBullet" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.AbstractBullet" />
    public abstract class BulletDecorator : AbstractBullet
    {
        /// <summary>
        /// The bullet to decorate
        /// </summary>
        protected AbstractBullet _bulletToDecorate;
        /// <summary>
        /// Initializes a new instance of the <see cref="BulletDecorator"/> class.
        /// </summary>
        /// <param name="bulletToDecorate">The bullet to decorate.</param>
        public BulletDecorator(AbstractBullet bulletToDecorate) : base(bulletToDecorate.Position, bulletToDecorate.Direction)
        {
            _bulletToDecorate = bulletToDecorate;
            Damage = _bulletToDecorate.Damage;
            Speed = _bulletToDecorate.Speed;

        }
        
    }
}
