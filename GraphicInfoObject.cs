using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class GraphicInfoObject.
    /// </summary>
    internal class GraphicInfoObject
    {
        /// <summary>
        /// The vertices
        /// </summary>
        private float[] _vertices;
        /// <summary>
        /// The texture object
        /// </summary>
        private Texture _textureObject;

        /// <summary>
        /// The element buffer object
        /// </summary>
        private int _elementBufferObject;

        /// <summary>
        /// The vertex buffer object
        /// </summary>
        private int _vertexBufferObject;

        /// <summary>
        /// The vertex array object
        /// </summary>
        private int _vertexArrayObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicInfoObject"/> class.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="textureObject">The texture object.</param>
        /// <param name="elementBufferObject">The element buffer object.</param>
        /// <param name="vertexBufferObject">The vertex buffer object.</param>
        /// <param name="vertexArrayObject">The vertex array object.</param>
        public GraphicInfoObject(float[] vertices, Texture textureObject, int elementBufferObject, int vertexBufferObject, int vertexArrayObject)
        {
            _vertices = vertices;
            _textureObject = textureObject;
            _elementBufferObject = elementBufferObject;
            _vertexBufferObject = vertexBufferObject;
            _vertexArrayObject = vertexArrayObject;
        }

        /// <summary>
        /// Gets or sets the element buffer object.
        /// </summary>
        /// <value>The element buffer object.</value>
        public int ElementBufferObject { get => _elementBufferObject; set => _elementBufferObject = value; }
        /// <summary>
        /// Gets or sets the vertex buffer object.
        /// </summary>
        /// <value>The vertex buffer object.</value>
        public int VertexBufferObject { get => _vertexBufferObject; set => _vertexBufferObject = value; }
        /// <summary>
        /// Gets or sets the vertex array object.
        /// </summary>
        /// <value>The vertex array object.</value>
        public int VertexArrayObject { get => _vertexArrayObject; set => _vertexArrayObject = value; }
        /// <summary>
        /// Gets the texture object.
        /// </summary>
        /// <value>The texture object.</value>
        internal Texture TextureObject { get => _textureObject; }
    }
}
