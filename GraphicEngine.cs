using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class GraphicEngine.
    /// </summary>
    internal class GraphicEngine
    {
        /// <summary>
        /// The shader
        /// </summary>
        private Shader _shader;

        /// <summary>
        /// Gets the shader.
        /// </summary>
        /// <value>The shader.</value>
        internal Shader Shader { get => _shader; }

        /// <summary>
        /// The shader vert path
        /// </summary>
        string _shaderVertPath;
        /// <summary>
        /// The shader frag path
        /// </summary>
        string _shaderFragPath;
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicEngine"/> class.
        /// </summary>
        /// <param name="shaderVertPath">The shader vert path.</param>
        /// <param name="shaderFragPath">The shader frag path.</param>
        public GraphicEngine(string shaderVertPath, string shaderFragPath)
        {
            _shaderFragPath= shaderFragPath;
            _shaderVertPath= shaderVertPath;
            _shader = new Shader(shaderVertPath, shaderFragPath);
        }
        /// <summary>
        /// Generates the vertex array buffer.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GenerateVertexArrayBuffer()
        {
            int _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            return _vertexArrayObject;
        }
        /// <summary>
        /// Generates the vertex buffer.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <returns>System.Int32.</returns>
        public static int GenerateVertexBuffer(float[] vertices)
        {
            
            int _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            return _vertexBufferObject;
        }
        /// <summary>
        /// Generates the indeces buffer.
        /// </summary>
        /// <param name="indices">The indices.</param>
        /// <returns>System.Int32.</returns>
        public static int GenerateIndecesBuffer(uint[] indices)
        {
            int _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
            return (_elementBufferObject);
        }
        /// <summary>
        /// Activates the shader.
        /// </summary>
        public void ActivateShader()
        {
            _shader.Use();

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            var texCoordLocation = _shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        }
    }
}
