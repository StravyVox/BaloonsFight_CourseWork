using GameLogicClassLibrary;

namespace GameNetLibrary
{
    /// <summary>
    /// Class GameOperator.
    /// </summary>
    public class GameOperator
    {
        /// <summary>
        /// Gets or sets the game over.
        /// </summary>
        /// <value>The game over.</value>
        public Action<int> GameOver { get; set; }
        /// <summary>
        /// The handler
        /// </summary>
        private RequestHandler _handler;
        /// <summary>
        /// The operator
        /// </summary>
        private PlayerObjectsOperator _operator;
        /// <summary>
        /// The scene frame object
        /// </summary>
        private SceneFrameObject _sceneFrameObject;
        /// <summary>
        /// Initializes a new instance of the <see cref="GameOperator"/> class.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="player">The player.</param>
        public GameOperator(string ip, string port, int player)
        {
            _handler = new RequestHandler(ip, port, player);
            _handler.actionOnRecieve += UpdateObjects;
            _operator = new PlayerObjectsOperator(player);
            _sceneFrameObject = new SceneFrameObject(player);
            _sceneFrameObject.SetScene(_operator);
        }

        /// <summary>
        /// Sends the objects to server.
        /// </summary>
        public async void SendObjectsToServer()
        {
            await _handler.FrameSendInfo(_sceneFrameObject);
        }
        /// <summary>
        /// Gets the objects from server.
        /// </summary>
        public async void GetObjectsFromServer()
        {
            await _handler.FrameGetInfo();
        }
        /// <summary>
        /// Updates the objects.
        /// </summary>
        /// <param name="frameObject">The frame object.</param>
        public void UpdateObjects(SceneFrameObject frameObject)
        {
            if (frameObject.Players.Length != 2)
            {
                GameOver( frameObject.Players[0].XPosition < 0 ? 1 : 2);
                return;
            }
            _sceneFrameObject = frameObject;
            _sceneFrameObject.SetScene(_operator);
            _operator.AddBonuses(_sceneFrameObject.Bonuses);
            _operator.UpgradePlayers(_sceneFrameObject.Players);
            _operator.AddBullets(_sceneFrameObject.Bullets);

        }
        /// <summary>
        /// Gets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public PlayerObjectsOperator Operator { get => _operator; }
        /// <summary>
        /// Gets or sets the handler.
        /// </summary>
        /// <value>The handler.</value>
        public RequestHandler Handler { get => _handler; set => _handler = value; }
        /// <summary>
        /// Gets or sets the scene frame object.
        /// </summary>
        /// <value>The scene frame object.</value>
        public SceneFrameObject SceneFrameObject { get => _sceneFrameObject; set => _sceneFrameObject = value; }
    }
}
