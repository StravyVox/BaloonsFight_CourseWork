using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using GameLogicClassLibrary;
namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class GraphicDrawer.
    /// </summary>
    internal class GraphicDrawer
    {

        /// <summary>
        /// The indices
        /// </summary>
        private readonly uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3
        };
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
        /// The graph engine
        /// </summary>
        private GraphicEngine _graphEngine;

        /// <summary>
        /// The list of objects to draw
        /// </summary>
        List<GraphicInfoObject> _listOfObjectsToDraw;
        /// <summary>
        /// The loader
        /// </summary>
        TexturePreLoader _loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicDrawer"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public GraphicDrawer(GraphicEngine engine)
        {
            _graphEngine = engine;
            _listOfObjectsToDraw = new List<GraphicInfoObject>();
            _loader = new TexturePreLoader();  
        }
        /// <summary>
        /// Reloads the positions of objects.
        /// </summary>
        /// <param name="objects">The objects.</param>
        public void ReloadPositionsOfObjects(List<GraphicObject> objects)
        {
            LoadObject(objects, true);
        }
        /// <summary>
        /// Loads the object.
        /// </summary>
        /// <param name="objectsToLoad">The objects to load.</param>
        /// <param name="reload">if set to <c>true</c> [reload].</param>
        public void LoadObject(List<GraphicObject> objectsToLoad, bool reload = false)
        {
            if (reload)
            {
                
                _listOfObjectsToDraw.ForEach(obj => {
                    GL.DeleteBuffer(obj.VertexBufferObject);
                    GL.DeleteBuffer(obj.ElementBufferObject);
                    GL.DeleteBuffer(obj.VertexArrayObject);
                    //GL.DeleteTexture(obj.TextureObject.Handle);
                    GL.DeleteVertexArray(obj.VertexArrayObject);
                    GL.DeleteFramebuffer(0);
                });
                _listOfObjectsToDraw = new List<GraphicInfoObject>();
            }
            foreach(GraphicObject obj in objectsToLoad)
            {
                LoadObject(obj);
            }
        }
        /// <summary>
        /// Loads the object.
        /// </summary>
        /// <param name="objectToLoad">The object to load.</param>
        public void LoadObject(GraphicObject objectToLoad)
        {
            float[] verticesForObject = GenerateVertices(objectToLoad);
            GenerateBuffers(objectToLoad,verticesForObject);
            _listOfObjectsToDraw.Add(new GraphicInfoObject(verticesForObject, _loader.LoadTexture(objectToLoad.TexturePath), _elementBufferObject, _vertexBufferObject, _vertexArrayObject));

        }
        /// <summary>
        /// Generates the vertices.
        /// </summary>
        /// <param name="graphObject">The graph object.</param>
        /// <returns>System.Single[].</returns>
        private float[] GenerateVertices(GraphicObject graphObject)
        {
             float[] _vertices =
            {
            // Position         Texture coordinates
             (graphObject.Position.X+(graphObject.Size.X/2)),  (graphObject.Position.Y+(graphObject.Size.Y/2)), 0.0f, 1.0f, 1.0f, // top right
             (graphObject.Position.X+(graphObject.Size.X/2)),  (graphObject.Position.Y-(graphObject.Size.Y/2)), 0.0f, 1.0f, 0.0f, // bottom right
             (graphObject.Position.X-(graphObject.Size.X/2)), (graphObject.Position.Y-(graphObject.Size.Y/2)), 0.0f, 0.0f, 0.0f, // bottom left
             (graphObject.Position.X-(graphObject.Size.X/2)),  (graphObject.Position.Y+(graphObject.Size.Y/2)), 0.0f, 0.0f, 1.0f  // top left
            };
            return _vertices;
        }

        /// <summary>
        /// Generates the buffers.
        /// </summary>
        /// <param name="graphObject">The graph object.</param>
        /// <param name="vertices">The vertices.</param>
        private void GenerateBuffers(GraphicObject graphObject, float[] vertices)
        {
            _vertexArrayObject = GraphicEngine.GenerateVertexArrayBuffer();
            _vertexBufferObject = GraphicEngine.GenerateVertexBuffer(vertices);
            _elementBufferObject = GraphicEngine.GenerateIndecesBuffer(_indices);     
        }
        /// <summary>
        /// Draws the element.
        /// </summary>
        public void DrawElement()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);
            foreach(GraphicInfoObject drawObject in _listOfObjectsToDraw)
            {
                
                GL.BindVertexArray(drawObject.VertexArrayObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer,drawObject.VertexBufferObject);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer,drawObject.ElementBufferObject);
                _graphEngine.ActivateShader();

                drawObject.TextureObject.Use(TextureUnit.Texture0);

                GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            }


        }

    }
}
