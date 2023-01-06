using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogicClassLibrary;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class PlayerGameLogic.
    /// Implements the <see cref="IBaseLogic" />
    /// </summary>
    /// <seealso cref="IBaseLogic" />
    public class PlayerGameLogic:IBaseLogic
    {
        /// <summary>
        /// The speed
        /// </summary>
        private float _speed;
        /// <summary>
        /// The shooter
        /// </summary>
        private ShootHandler _shooter;
        /// <summary>
        /// The player
        /// </summary>
        private int _player;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerGameLogic"/> class.
        /// </summary>
        /// <param name="gameObjects">The game objects.</param>
        /// <param name="player">The player.</param>
        public PlayerGameLogic(List<GameObject> gameObjects, int player)
        {
            _player = player;
            GameObjects = gameObjects;
            Bullets = new List<AbstractBullet>();
            Players = new List<Balloon>();
            Players.Add((Balloon)gameObjects[0]);
            Players.Add((Balloon)gameObjects[1]);
            _speed = 10f;
             Players[0].DestroyAction += GameOver;
             Players[1].DestroyAction += GameOver;
             _shooter = new ShootHandler((Balloon)Players[_player]);
      
        }

        /// <summary>
        /// Frames the logic.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        public void FrameLogic(float DeltaTime)//Производит базовую логику на кадре. Вызывает методы кадра у объектов, проверяет попадание пуль
        {
              
                if (Players.Count > 0)
                {
                FrameWorker.FrameMove(DeltaTime, new List<GameObject>() { Players[_player] });
                }
                _shooter.Frame(DeltaTime);
        }
        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        public void MovePlayer(float DeltaTime)
        {
            if (Players[_player].Fuel > 0)
            {
                ObjectMover.MoveObjectByY(Players[_player], 0.01f, _speed * DeltaTime);
            }
        }

        /// <summary>
        /// Shoots this instance.
        /// </summary>
        public void Shoot()
        {
                AbstractBullet bullet = (AbstractBullet)_shooter.Shoot();
                if (bullet != null)
                {
                    Bullets.Add(bullet);
                    
                }
        }
        /// <summary>
        /// Games the over.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.Exception">Game over</exception>
        public void GameOver(GameObject obj)
        {
            throw new Exception("Game over");
        }
        /// <summary>
        /// Gets or sets the game objects.
        /// </summary>
        /// <value>The game objects.</value>
        public List<GameObject> GameObjects { get; set; }
        /// <summary>
        /// Gets or sets the bullets.
        /// </summary>
        /// <value>The bullets.</value>
        public List<AbstractBullet> Bullets { get; set; }
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>The players.</value>
        public List<Balloon> Players { get; set; }
        /// <summary>
        /// Gets or sets the collission objects.
        /// </summary>
        /// <value>The collission objects.</value>
    }
}
