using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class Balloon.
    /// Implements the <see cref="GameLogicClassLibrary.GameObject" />
    /// Implements the <see cref="GameLogicClassLibrary.IFrame" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.GameObject" />
    /// <seealso cref="GameLogicClassLibrary.IFrame" />
    public class Balloon : GameObject, IFrame
    {

        /// <summary>
        /// The take damage time
        /// </summary>
        private float _takeDamageTime;
        /// <summary>
        /// Gets or sets the armor.
        /// </summary>
        /// <value>The armor.</value>
        public int Armor { get; set; }
        /// <summary>
        /// Gets or sets the fuel.
        /// </summary>
        /// <value>The fuel.</value>
        public float Fuel { get; set; }
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public float Speed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        /// <param name="texturePath">The texture path.</param>
        /// <param name="position">The position.</param>
        public Balloon(string texturePath, Vector2 position) : base(texturePath, position, new Vector2(0.3f, 0.3f))
        {
            HP = 1;
            Speed = 5;
            Armor = 3;
            Fuel = 100;
            _takeDamageTime = 0.5f;
        }
        /// <summary>
        /// Takes the damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        public override void TakeDamage(int damage)
        {

            if (Armor > 0)
            {
                Armor-= damage;
            }
            else
            {
                HP-= damage;
            }
            
            
        }

        /// <summary>
        /// Frames the specified delta time.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        /// <returns>System.Int32.</returns>
        public int Frame(float DeltaTime)
        {
            ObjectMover.MoveObjectByY(this, -0.01f, Speed * DeltaTime);
            Fuel -= DeltaTime*4;
            
            return 0;
        }


    }
}
