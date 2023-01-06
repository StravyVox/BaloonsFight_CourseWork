using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using GameLogicClassLibrary;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class PlayerObjectsOperator.    
    /// Implements the <see cref="IObjectsOperator" />
    /// </summary>
    /// <seealso cref="IObjectsOperator" />
    public class PlayerObjectsOperator:IObjectsOperator
    {
        /// <summary>
        /// The player
        /// </summary>
        private int _player;
        /// <summary>
        /// The first player
        /// </summary>
        private Balloon _firstPlayer;
        /// <summary>
        /// The second player
        /// </summary>
        private Balloon _secondPlayer;
        /// <summary>
        /// The logic operator
        /// </summary>
        private PlayerGameLogic _logicOperator;
        /// <summary>
        /// The draw objects
        /// </summary>
        List<GameObject> _drawObjects;
        /// <summary>
        /// The bonuses
        /// </summary>
        private List<AbstractBonus> _bonuses;
        /// <summary>
        /// Gets the logic operator.
        /// </summary>
        /// <value>The logic operator.</value>
        public PlayerGameLogic LogicOperator { get => _logicOperator;  }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerObjectsOperator"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerObjectsOperator(int player)
        {
            _player = player;
            _firstPlayer = new Balloon("Resources\\Baloon.png", new Vector2(-0.85f, 0f));
            _secondPlayer = new Balloon("Resources\\Baloon.png", new Vector2(0.85f, 0f));
            _drawObjects = new List<GameObject>() { _firstPlayer, _secondPlayer };
            _bonuses = new List<AbstractBonus>();
            _logicOperator = new PlayerGameLogic(_drawObjects, _player);
        }
        /// <summary>
        /// Adds the bullets.
        /// </summary>
        /// <param name="bullets">The bullets.</param>
        public void AddBullets(AbstractBullet[] bullets)
        {
                _logicOperator.Bullets.Clear();
                _logicOperator.Bullets.AddRange(bullets);
        }
        /// <summary>
        /// Upgrades the players.
        /// </summary>
        /// <param name="player">The player.</param>
        public void UpgradePlayers(Balloon[] player)
        {
            if(_player == 0)
            {
                _logicOperator.Players[1].Position = player[1].Position;

            }
            else
            {
                _logicOperator.Players[0].Position = player[0].Position;
            }
            _logicOperator.Players[_player].Fuel = player[_player].Fuel> _logicOperator.Players[_player].Fuel ? player[_player].Fuel : _logicOperator.Players[_player].Fuel;
            _logicOperator.Players[1].HP = player[1].HP;
            _logicOperator.Players[1].Armor = player[1].Armor;
            _logicOperator.Players[0].HP = player[0].HP;
            _logicOperator.Players[0].Armor = player[0].Armor;
        }
        /// <summary>
        /// Adds the bonuses.
        /// </summary>
        /// <param name="bonuses">The bonuses.</param>
        public void AddBonuses(AbstractBonus[] bonuses)
        {
            if (bonuses.Length > 0)
            {
                _bonuses.Clear();
                _bonuses.AddRange(bonuses);
            }
        }
        /// <summary>
        /// Returns the objects.
        /// </summary>
        /// <returns>List&lt;GraphicObject&gt;.</returns>
        public List<GraphicObject> ReturnObjects()
        {
            List<GraphicObject> objects = new List<GraphicObject>();
            objects.AddRange(_logicOperator.Bullets);
            objects.AddRange(_logicOperator.Players);
            objects.AddRange(_bonuses);
            objects.AddRange(UIObjectsOperator.ReturnFuel(_logicOperator.Players[_player]));
            objects.AddRange(UIObjectsOperator.ReturnHP(_logicOperator.Players[_player]));
            objects.AddRange(UIObjectsOperator.ReturnArmor(_logicOperator.Players[_player]));
            return objects;
        }
        /// <summary>
        /// Gets the bullets.
        /// </summary>
        /// <returns>List&lt;AbstractBullet&gt;.</returns>
        public List<AbstractBullet> GetBullets() 
        {
            return _logicOperator.Bullets;
        }
        /// <summary>
        /// Gets the players.
        /// </summary>
        /// <returns>List&lt;Balloon&gt;.</returns>
        public List<Balloon> GetPlayers() 
        {
            return _logicOperator.Players;
        }

    }
}
