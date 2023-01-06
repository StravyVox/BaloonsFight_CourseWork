using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class TexturePreLoader.
    /// </summary>
    internal class TexturePreLoader
    {
        /// <summary>
        /// The textures
        /// </summary>
        Dictionary<String, Texture> Textures;
        /// <summary>
        /// Gets or sets the texture pathes.
        /// </summary>
        /// <value>The texture pathes.</value>
        public List<String> TexturePathes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TexturePreLoader"/> class.
        /// </summary>
        public TexturePreLoader() {
            TexturePathes = new List<String>();
            Textures =  new Dictionary<String, Texture>();
        }
        /// <summary>
        /// Loads the texture.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Texture.</returns>
        public Texture LoadTexture(String path)
        {
            if (Textures.ContainsKey(path))
            {
                return Textures[path];
            }
            else
            {
                Textures.Add(path, Texture.LoadFromFile(path));
                return Textures[path];
            }
        }
        
         
    }
}
