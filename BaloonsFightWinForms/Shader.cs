using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class Shader.
    /// </summary>
    internal class Shader
    {
        /// <summary>
        /// The handle
        /// </summary>
        public readonly int Handle;

        /// <summary>
        /// The uniform locations
        /// </summary>
        private readonly Dictionary<string, int> _uniformLocations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shader"/> class.
        /// </summary>
        /// <param name="vertPath">The vert path.</param>
        /// <param name="fragPath">The frag path.</param>
        public Shader(string vertPath, string fragPath)
        {
           

            var shaderSource = File.ReadAllText(vertPath);

            var vertexShader = GL.CreateShader(ShaderType.VertexShader);

            GL.ShaderSource(vertexShader, shaderSource);

            CompileShader(vertexShader);

            shaderSource = File.ReadAllText(fragPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderSource);
            CompileShader(fragmentShader);

            
            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);

            LinkProgram(Handle);

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

          
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            _uniformLocations = new Dictionary<string, int>();

            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(Handle, i, out _, out _);
                var location = GL.GetUniformLocation(Handle, key);

                _uniformLocations.Add(key, location);
            }
        }

        /// <summary>
        /// Compiles the shader.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <exception cref="System.Exception">Error occurred whilst compiling Shader({shader}).\n\n{infoLog}</exception>
        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }
        }

        /// <summary>
        /// Links the program.
        /// </summary>
        /// <param name="program">The program.</param>
        /// <exception cref="System.Exception">Error occurred whilst linking Program({program})</exception>
        private static void LinkProgram(int program)
        {
            // We link the program
            GL.LinkProgram(program);

            // Check for linking errors
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                throw new Exception($"Error occurred whilst linking Program({program})");
            }
        }

        /// <summary>
        /// Uses this instance.
        /// </summary>
        public void Use()
        {
            GL.UseProgram(Handle);
        }

        /// <summary>
        /// Gets the attribute location.
        /// </summary>
        /// <param name="attribName">Name of the attribute.</param>
        /// <returns>System.Int32.</returns>
        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(Handle, attribName);
        }
        /// <summary>
        /// Sets the int.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public void SetInt(string name, int data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformLocations[name], data);
        }

        /// <summary>
        /// Sets the float.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public void SetFloat(string name, float data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformLocations[name], data);
        }

        /// <summary>
        /// Sets the matrix4.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Handle);
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }
        /// <summary>
        /// Sets the vector3.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        public void SetVector3(string name, Vector3 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform3(_uniformLocations[name], data);
        }
    }
}
