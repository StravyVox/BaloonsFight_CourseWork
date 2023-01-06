using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Numerics;
using GameLogicClassLibrary;
using GameLogicClassLibrary;

namespace GameNetLibrary
{

    /// <summary>
    /// Class SceneFrameObject.
    /// </summary>
    public class SceneFrameObject
    {

        /// <summary>
        /// The bullets
        /// </summary>
        private AbstractBullet[] _bullets;
        /// <summary>
        /// The players
        /// </summary>
        private Balloon[] _players;
        /// <summary>
        /// The bonuses
        /// </summary>
        private AbstractBonus[] _bonuses;
        /// <summary>
        /// The game scene
        /// </summary>
        private IObjectsOperator _gameScene;

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        public int Player { get; set; }
        /// <summary>
        /// Gets or sets the bullets.
        /// </summary>
        /// <value>The bullets.</value>
        public AbstractBullet[] Bullets { get => _bullets.ToArray(); set => _bullets = value; }
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>The players.</value>
        public Balloon[] Players { get => _players.ToArray(); set => _players = value; }

        /// <summary>
        /// Gets or sets the bonuses.
        /// </summary>
        /// <value>The bonuses.</value>
        public AbstractBonus[] Bonuses { get => _bonuses; set => _bonuses = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneFrameObject"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public SceneFrameObject(int player)
        {
            Player = player;
        }
        /// <summary>
        /// Sets the scene.
        /// </summary>
        /// <param name="gameScene">The game scene.</param>
        public void SetScene(IObjectsOperator gameScene)
        {
            _gameScene = gameScene;
        }
        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Serialize()
        {
            string resultOfSerialize = JsonSerializer.Serialize(this);
            return resultOfSerialize;
        }
        /// <summary>
        /// Copies the scene to json.
        /// </summary>
        /// <returns>System.String.</returns>
        public string CopySceneToJSON()
        {
            List<AbstractBullet> list = new List<AbstractBullet>();
            _gameScene.GetBullets().ForEach(bullet => list.Add((AbstractBullet)bullet));
            _bullets = list.ToArray();
            _players = _gameScene.GetPlayers().ToArray();
            string resultOfSerialize = JsonSerializer.Serialize(this);
            return resultOfSerialize;
        }
    }
}
