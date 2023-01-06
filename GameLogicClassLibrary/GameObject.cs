using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class GameObject.
    /// Implements the <see cref="GameLogicClassLibrary.GraphicObject" />
    /// Implements the <see cref="IDisposable" />
    /// </summary>
    /// <seealso cref="GameLogicClassLibrary.GraphicObject" />
    /// <seealso cref="IDisposable" />
    public class GameObject : GraphicObject, IDisposable
    {
        /// <summary>
        /// The destroy action
        /// </summary>
        public Action<GameObject>? DestroyAction;
        /// <summary>
        /// Gets or sets the hp.
        /// </summary>
        /// <value>The hp.</value>
        public int HP { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="texturePath">The texture path.</param>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        public GameObject(string texturePath, Vector2 position, Vector2 size) : base(texturePath, position, size)
        {

        }
        /// <summary>
        /// Takes the damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        public virtual void TakeDamage(int damage)
        {
            //HP-=damage;
            
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            DestroyAction?.Invoke(this);
        }
    }
}
