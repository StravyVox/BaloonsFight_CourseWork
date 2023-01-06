using System.Numerics;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class GraphicObject.
    /// </summary>
    public class GraphicObject
    {
        /// <summary>
        /// The texture path
        /// </summary>
        private string _texturePath;
        /// <summary>
        /// The position
        /// </summary>
        private Vector2 _position;
        /// <summary>
        /// The size
        /// </summary>
        private Vector2 _size;
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicObject"/> class.
        /// </summary>
        /// <param name="texturePath">The texture path.</param>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        public GraphicObject(string texturePath, Vector2 position, Vector2 size)
        {
            _texturePath = texturePath;
            _position = position;
            _size = size;
        }

        /// <summary>
        /// Gets the texture path.
        /// </summary>
        /// <value>The texture path.</value>
        public string TexturePath { get => _texturePath; }
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector2 Position { get => _position; set => _position = value; }
        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        /// <value>The x position.</value>
        public float XPosition { get => _position.X; set => _position.X = value; }
        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        /// <value>The y position.</value>
        public float YPosition { get => _position.Y; set => _position.Y = value; }
        /// <summary>
        /// Gets or sets the size of the x.
        /// </summary>
        /// <value>The size of the x.</value>
        public float XSize { get => _size.X; set => _size.X = value; }
        /// <summary>
        /// Gets or sets the size of the y.
        /// </summary>
        /// <value>The size of the y.</value>
        public float YSize { get => _size.Y; set => _size.Y = value; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Vector2 Size { get => _size; protected set => _size = value; }
    }
}