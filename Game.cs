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
using GameNetLibrary;

namespace BaloonsFightWinForms
{

    /// <summary>
    /// Class Game.
    /// Implements the <see cref="GameWindow" />
    /// </summary>
    /// <seealso cref="GameWindow" />
    public class Game : GameWindow
    {
        /// <summary>
        /// The buffer send
        /// </summary>
        public const float BufferSend = 0.05f;
        /// <summary>
        /// The buffer recieve
        /// </summary>
        public const float BufferRecieve = 0.05f;
        /// <summary>
        /// Gets or sets the closed.
        /// </summary>
        /// <value>The closed.</value>
        public Action Closed { get; set; }
        /// <summary>
        /// The is host
        /// </summary>
        private bool _isHost;
        /// <summary>
        /// The game over
        /// </summary>
        private bool _gameOver;
        /// <summary>
        /// The engine
        /// </summary>
        private GraphicEngine _engine;
        /// <summary>
        /// The drawer
        /// </summary>
        private GraphicDrawer _drawer;

        /// <summary>
        /// The timer for send
        /// </summary>
        private float timerForSend;
        /// <summary>
        /// The timer for recieve
        /// </summary>
        private float timerForRecieve;

        /// <summary>
        /// The game operator
        /// </summary>
        private GameOperator _gameOperator;
        /// <summary>
        /// The game objects operator
        /// </summary>
        private IObjectsOperator _gameObjectsOperator;
        /// <summary>
        /// The game logic operator
        /// </summary>
        private IBaseLogic _gameLogicOperator;


        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <param name="IsHost">if set to <c>true</c> [is host].</param>
        /// <param name="gameWindowSettings">The game window settings.</param>
        /// <param name="nativeWindowSettings">The native window settings.</param>
        public Game(string ip, string port, bool IsHost, GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            timerForSend = 0.1f;
            timerForRecieve = 0.2f;
            _gameOver = false;
            _isHost = IsHost;
            if (IsHost)
            {
                _gameOperator = new GameOperator(ip, port,0);
            }
            else
            {
                _gameOperator = new GameOperator(ip, port, 1);
            }
            _gameOperator.SendObjectsToServer();
            _gameObjectsOperator = _gameOperator.Operator;
            _gameLogicOperator = ((PlayerObjectsOperator)_gameObjectsOperator).LogicOperator;
            _gameOperator.GameOver = GameOver;

        }
        /// <summary>
        /// Run immediately after Run() is called.
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            _engine = new GraphicEngine("shader.vert", "shader.frag");
            _drawer = new GraphicDrawer(_engine);
            _drawer.LoadObject(_gameObjectsOperator.ReturnObjects());

        }

        /// <summary>
        /// Handles the <see cref="E:RenderFrame" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FrameEventArgs"/> instance containing the event data.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            _drawer.DrawElement();
            SwapBuffers();
        }

        /// <summary>
        /// Handles the <see cref="E:UpdateFrame" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FrameEventArgs"/> instance containing the event data.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)//Главная логика приложения
        {
            base.OnUpdateFrame(e);
            float deltaTime = (float)e.Time;
            timerForSend -= deltaTime;
            timerForRecieve -= deltaTime;
            var input = KeyboardState;

            try { _drawer.ReloadPositionsOfObjects(_gameObjectsOperator.ReturnObjects()); }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Enter) && !_gameOver)
            {
                _gameLogicOperator.Shoot();
                timerForRecieve+= deltaTime;
            }
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Tab))
            {
                Closed.Invoke();
                Close();
                return;
            }
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Space) && !_gameOver)
            {
                _gameLogicOperator.MovePlayer(deltaTime);
            }
            
            else if(!_gameOver)
            {

                _gameLogicOperator.FrameLogic(deltaTime);

            }
            if (!_gameOver)
            {
                OperationsWithServer();
            }
        }
        /// <summary>
        /// Operationses the with server.
        /// </summary>
        private async void OperationsWithServer()
        {
            try
            {
                    if (timerForRecieve <= 0)
                    {
                        timerForRecieve = BufferRecieve;
                        await _gameOperator.Handler.FrameGetInfo();
                    }
                    if (timerForSend <= 0)
                    {
                        await _gameOperator.Handler.FrameSendInfo(_gameOperator.SceneFrameObject);
                        timerForSend = BufferSend;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
                Close();
               
            }
        }
        /// <summary>
        /// Raises the <see cref="E:OpenTK.Windowing.Desktop.NativeWindow.Resize" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:OpenTK.Windowing.Common.ResizeEventArgs" /> that contains the event data.</param>
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }
        /// <summary>
        /// Games the over.
        /// </summary>
        private void GameOver()
        {
            _gameOver = true;
            Closed.Invoke();
            Close();

        }
    }
}
