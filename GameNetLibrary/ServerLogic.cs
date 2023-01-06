using GameLogicClassLibrary;
using GameNetLibrary;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameNetLibrary
{
    /// <summary>
    /// Class ServerLogic.
    /// </summary>
    public class ServerLogic
    {
        /// <summary>
        /// The locker
        /// </summary>
        object _locker;
        /// <summary>
        /// The scene
        /// </summary>
        SceneFrameObject _scene;
        float _timeToTakeDamage;
        /// <summary>
        /// The connection
        /// </summary>
        ConnectionHandler _connection;
        /// <summary>
        /// The bonus generator
        /// </summary>
        BonusGenerator _bonusGenerator;
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerLogic"/> class.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public ServerLogic(string ip, string port)
        {
            _connection= new ConnectionHandler(ip, port);
            _locker = new();
            _bonusGenerator = new BonusGenerator();
            _timeToTakeDamage = 0f;
        }
        /// <summary>
        /// Runs the server.
        /// </summary>
        public void RunServer()
        {
            _connection.ActionWithoutReturn = FirstStart;
            _connection.ActionWithReturn = ReturnObjectsForClient;
            _connection.ActionOnConnect = FrameLogic;
            _connection.Start();
        }
        /// <summary>
        /// Firsts the start.
        /// </summary>
        /// <param name="JSONResponse">The json response.</param>
        private void FirstStart(string JSONResponse)
        {
            SceneFrameObject frameObject = JsonSerializer.Deserialize<SceneFrameObject>(JSONResponse);
            if (frameObject != null)
            {
                //Устанавливаем новые обработчки событий
                _connection.ActionWithoutReturn = UpdateObjects;
                _connection.ActionWithReturn = ReturnObjectsForClient;
                _connection.ActionOnConnect = FrameLogic;
                //Устанавливаем текущую сцену

                _scene = frameObject;
                _scene.Bonuses = new List<AbstractBonus>().ToArray();
                //Console.WriteLine("Scene created");
            }
        }

        /// <summary>
        /// Frames the logic.
        /// </summary>
        private void FrameLogic()
        {
            if(_scene!=null)
            {
                if (_scene.Bullets.Length > 0)
                {
                    lock (_locker)
                    {
                        foreach (AbstractBullet bullet in _scene.Bullets)
                        {
                            bullet.Frame(0.3f);
                        }

                    }
                }
                if (_scene.Bonuses.Length > 0)
                {
                    lock (_locker)
                    {
                        foreach(AbstractBonus bonus in _scene.Bonuses)
                        {
                            bonus.Frame(0.3f);
                        }
                    }
                }

                CollissionCheck();
                CheckRemoveObjects();
                
            }
        }
        /// <summary>
        /// Checks the remove bullets.
        /// </summary>
        private void CheckRemoveObjects()
        {
           
            if (_scene.Players.Length == 2)
            {
                List<Balloon> playersBuff = new List<Balloon>();
                for (int i = 0; i < _scene.Players.Length; i++)
                {

                    if (_scene.Players[i].YPosition > -1.0f)
                    {
                       playersBuff.Add( _scene.Players[i]);
                    }
                }
                _scene.Players = playersBuff.ToArray();
            }
        }
        /// <summary>
        /// Collissions the check.
        /// </summary>
        private void CollissionCheck()
        {
            lock(_locker){
            _timeToTakeDamage -= 0.1f;
            List<AbstractBullet> bullets = _scene.Bullets.ToList();
            List<Balloon> players = _scene.Players.ToList();
            List<AbstractBonus> bonuses = _scene.Bonuses.ToList();

            
                BonusCollissionOperator.BonusCheckCollission(bullets,bonuses, players);

                if (_timeToTakeDamage < 0)
                {
                    int countOfBullets = bullets.Count;
                    FrameWorker.FrameCheckCollission(bullets, players);
                    if (countOfBullets > bullets.Count) _timeToTakeDamage = 1.5f;

                }

                List<AbstractBullet> bulletArray = new List<AbstractBullet> { };
                foreach (AbstractBullet bullet in bullets) bulletArray.Add(bullet);
          
                _scene.Players = players.ToArray();
                _scene.Bullets = bulletArray.ToArray();
                _scene.Bonuses = bonuses.ToArray();
            }
            
        }
        /// <summary>
        /// Returns the objects for client.
        /// </summary>
        /// <param name="JSONResponse">The json response.</param>
        /// <returns>System.String.</returns>
        private string ReturnObjectsForClient(string JSONResponse)
        {

            //Console.WriteLine("Player "+_scene.Player+" x(" + _scene.Players[0].XPosition +") y(" + _scene.Players[0].YPosition +")");
                if (_scene != null)
            {
                string result = _scene.Serialize();
                
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the objects.
        /// </summary>
        /// <param name="JSONResponse">The json response.</param>
        public void UpdateObjects(String JSONResponse)
        {
            SceneFrameObject frameObject = JsonSerializer.Deserialize<SceneFrameObject>(JSONResponse);
            lock (_locker)
            {
                SwitchBullets(frameObject);

                //_scene.Players = frameObject.Players;
                SwitchPlayers(frameObject);
            }
        }

        /// <summary>
        /// Switches the players.
        /// </summary>
        /// <param name="player">The player.</param>
        private void SwitchPlayers(SceneFrameObject player)
        {
            if(_scene.Players.Length!=2) { return; }
            switch (player.Player)
            {
                case 0:

                    _scene.Players[0].Position = player.Players[0].Position;
                    _scene.Players[0].Fuel = player.Players[0].Fuel;

                    break;
                case 1:
                    _scene.Players[1].Position = player.Players[1].Position;
                    _scene.Players[1].Fuel = player.Players[1].Fuel;
                    break;
            }
        }
        /// <summary>
        /// Switches the bullets.
        /// </summary>
        /// <param name="player">The player.</param>
        private void SwitchBullets(SceneFrameObject player)
        {
            if (player.Bullets.Count() > _scene.Bullets.Count())
            {
                GenerateBonus();
                if (_timeToTakeDamage < 0)
                {
                    _scene.Bullets = player.Bullets;
                }
            }
            else
            {
               for(int i = 0; i<player.Bullets.Count(); i++) 
                {
                    _scene.Bullets[i] = player.Bullets[i]; 
                }
            }

        }
        /// <summary>
        /// Generates the bonus.
        /// </summary>
        private void GenerateBonus()
        {
            List<AbstractBonus> bonus = new List<AbstractBonus>();
            if(_scene.Bonuses.Length> 0) bonus.AddRange(_scene.Bonuses);
            bonus.Add(_bonusGenerator.Generate());
            _scene.Bonuses = bonus.ToArray();
        }
    }
}
