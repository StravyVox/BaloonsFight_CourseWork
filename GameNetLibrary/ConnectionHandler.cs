using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GameNetLibrary
{
    /// <summary>
    /// Class ConnectionHandler.
    /// </summary>
    public class ConnectionHandler
    {
        /// <summary>
        /// The locker
        /// </summary>
        private object _locker;
        /// <summary>
        /// The ip adress
        /// </summary>
        private string _ipAdress;
        /// <summary>
        /// The port
        /// </summary>
        private string _port;
        /// <summary>
        /// The listener
        /// </summary>
        private HttpListener _listener;
        /// <summary>
        /// The stop flag
        /// </summary>
        private bool _stopFlag;
        /// <summary>
        /// Delegate SceneJSONAction
        /// </summary>
        /// <param name="JSONResponse">The json response.</param>
        /// <returns>System.String.</returns>
        public delegate string SceneJSONAction(string JSONResponse);
        /// <summary>
        /// Gets or sets the action with return.
        /// </summary>
        /// <value>The action with return.</value>
        public SceneJSONAction ActionWithReturn { get; set; }
        /// <summary>
        /// Gets or sets the action without return.
        /// </summary>
        /// <value>The action without return.</value>
        public Action<string> ActionWithoutReturn { get; set; }
        /// <summary>
        /// Gets or sets the action on connect.
        /// </summary>
        /// <value>The action on connect.</value>
        public Action ActionOnConnect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionHandler"/> class.
        /// </summary>
        /// <param name="ipAdress">The ip adress.</param>
        /// <param name="port">The port.</param>
        public ConnectionHandler(string ipAdress, string port)
        {
            _locker = new();
            _ipAdress = ipAdress;
            _port = port;
            _listener = new HttpListener();
            _stopFlag = false;
            string connectionString = "http://" + _ipAdress + ":" + port + "/";
            Console.WriteLine("Started on "+connectionString);
            _listener.Prefixes.Add(connectionString);
            
        }
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public async void Start()
        {

            try
            {
                _listener.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            while (!_stopFlag)
            {
                var context = await _listener.GetContextAsync();

                ActionOnConnect();
                ThreadPool.QueueUserWorkItem(CheckContext, new object[] { context });
                
            }
        }

        /// <summary>
        /// Checks the context.
        /// </summary>
        /// <param name="state">The state.</param>
        private async void CheckContext(object state)
        {
            object[] array = state as object[];
            var context = array[0] as HttpListenerContext;
            var response = context.Response;
            string Info;
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                Info = reader.ReadToEnd();
            }
            if (context.Request.HttpMethod == "GET")
            {

                response.AddHeader("Content-Type", "application/json");
                string answer = ActionWithReturn(Info);
                if (answer != null)
                {
                    using Stream stream = response.OutputStream;
                    Byte[] bytes = Encoding.UTF8.GetBytes(answer);
                    await stream.WriteAsync(bytes);
                    await stream.FlushAsync();
                }
                context.Response.Close();
            }
            else
            {
                ActionWithoutReturn(Info);
                context.Response.Close();
            }
        }
    }
}
