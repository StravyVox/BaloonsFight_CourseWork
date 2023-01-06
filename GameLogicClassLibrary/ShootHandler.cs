using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogicClassLibrary;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class ShootHandler.
    /// Implements the <see cref="IFrame" />
    /// </summary>
    /// <seealso cref="IFrame" />
    internal class ShootHandler:IFrame
    {
        /// <summary>
        /// The player
        /// </summary>
        public Balloon _Player;
        /// <summary>
        /// The able to shoot
        /// </summary>
        public bool AbleToShoot;
        /// <summary>
        /// The reload
        /// </summary>
        private float _reload;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShootHandler"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public ShootHandler(Balloon player)
        {
            _Player = player;
            _reload = 1.0f;
            AbleToShoot = true;
        }
        /// <summary>
        /// Shoots this instance.
        /// </summary>
        /// <returns>AbstractBullet.</returns>
        public AbstractBullet Shoot()
        {
            if (AbleToShoot)
            {
                AbleToShoot = false;
                AbstractBullet bullet = new AbstractBullet(new System.Numerics.Vector2(_Player.Position.X<0? _Player.Position.X+0.2f: _Player.Position.X - 0.2f, _Player.Position.Y), _Player.XPosition<0?1:-1);
                return bullet;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Frames the specified delta time.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        /// <returns>System.Int32.</returns>
        public int Frame(float DeltaTime)
        {
            if (!AbleToShoot)
            {
                _reload -= DeltaTime;
                if (_reload <= 0)
                { AbleToShoot = true;
                    _reload = 1.0f;
                }
            }
            return 0;
        }
    }
}
