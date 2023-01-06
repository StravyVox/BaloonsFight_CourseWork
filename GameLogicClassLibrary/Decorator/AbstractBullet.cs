using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenTK.Graphics.OpenGL.GL;
using System.Numerics;
namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class AbstractBullet.
    /// Implements the <see cref="GameLogicClassLibrary.GameObject" />
    /// Implements the <see cref="GameLogicClassLibrary.IFrame" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.GameObject" />
    /// <seealso cref="GameLogicClassLibrary.IFrame" />
    public class AbstractBullet : GameObject, IFrame
    {
        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public int Damage { get; set; }
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public int Direction { get; set; }
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public float Speed { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBullet"/> class.
        /// </summary>
        public AbstractBullet() : base("Resources\\Ball.png", new Vector2(0.0f, 0.0f), new Vector2(0.1f, 0.1f))
        {
            Speed = 0.01f;
            Damage = 1;
            HP = 1;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBullet"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="XDirection">The x direction.</param>
        public AbstractBullet(Vector2 position, int XDirection) : base("Resources\\Ball.png", position, new Vector2(0.1f, 0.1f))
        {
            Speed = 0.01f;
            Damage = 1;
            HP = 1;
            Direction = XDirection;
        }
        /// <summary>
        /// Frames the specified delta time.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        /// <returns>System.Int32.</returns>
        public int Frame(float DeltaTime)
        {
            if (Direction < 0)
            {
                ObjectMover.MoveObjectByX(this, -1, DeltaTime * Speed);

            }
            else
            {
                ObjectMover.MoveObjectByX(this, 1, DeltaTime * Speed);

            }
            return 0;
        }
    }
}
