using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameNetLibrary
{
    /// <summary>
    /// Class RequestHandler.
    /// </summary>
    public class RequestHandler
    {
        /// <summary>
        /// The connection
        /// </summary>
        private HttpClient _connection;
        /// <summary>
        /// The player
        /// </summary>
        private int _player;
        /// <summary>
        /// The ip adress
        /// </summary>
        private string _ipAdress;
        /// <summary>
        /// The port
        /// </summary>
        private string _port;
        /// <summary>
        /// Delegate RecievedInfo
        /// </summary>
        /// <param name="scene">The scene.</param>
        public delegate void RecievedInfo(SceneFrameObject scene);
        /// <summary>
        /// The action on recieve
        /// </summary>
        public RecievedInfo actionOnRecieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHandler"/> class.
        /// </summary>
        /// <param name="ipAdress">The ip adress.</param>
        /// <param name="port">The port.</param>
        /// <param name="player">The player.</param>
        public RequestHandler(string ipAdress, string port, int player)
        {
            _player= player;
            _port = port;
            _ipAdress = ipAdress;
            _connection = new HttpClient();

        }
        /// <summary>
        /// Frames the get information.
        /// </summary>
        public async Task FrameGetInfo()//Вызов информации для получения запроса первичного для клиента
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            using var response = await _connection.GetAsync("http://"+_ipAdress + ":" + _port);
            //Console.WriteLine("ResultFromConnection: "+ response.StatusCode);
            SceneFrameObject sceneFrameObject = await response.Content.ReadFromJsonAsync<SceneFrameObject>();
            timer.Stop();
            //Console.WriteLine("Elapsed time on request is {0} ms", timer.ElapsedMilliseconds);
            sceneFrameObject.Player = _player;
            await Task.Run(()=>actionOnRecieve(sceneFrameObject));
        }
        /// <summary>
        /// Frames the send information.
        /// </summary>
        /// <param name="sceneFrameObject">The scene frame object.</param>
        public async Task FrameSendInfo(SceneFrameObject sceneFrameObject) 
        {
            JsonSerializerOptions options= new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            try
            {
                sceneFrameObject.CopySceneToJSON();
                await _connection.PostAsJsonAsync<SceneFrameObject>("http://" + _ipAdress + ":" + _port, sceneFrameObject,options);
            }
            catch
            {
                
            }
            
        }
    }
}
