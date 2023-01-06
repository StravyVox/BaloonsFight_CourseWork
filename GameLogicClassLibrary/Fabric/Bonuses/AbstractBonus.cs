using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class AbstractBonus.
    /// Implements the <see cref="GameLogicClassLibrary.GameObject" />
    /// Implements the <see cref="GameLogicClassLibrary.IFrame" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.GameObject" />
    /// <seealso cref="GameLogicClassLibrary.IFrame" />
    public class AbstractBonus : GameObject, IFrame
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBonus"/> class.
        /// </summary>
        /// <param name="Description">The description.</param>
        /// <param name="texturePath">The texture path.</param>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        public AbstractBonus(string Description, string texturePath, Vector2 position, Vector2 size) : base(texturePath, position, size)
        {

            HP = 1;
            this.Description = Description;
        }

        /// <summary>
        /// Frames the specified delta time.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        /// <returns>System.Int32.</returns>
        public int Frame(float DeltaTime)
        {
            ObjectMover.MoveObjectByY(this, -0.01f, DeltaTime);
            return 0;
        }
        
    }
}
