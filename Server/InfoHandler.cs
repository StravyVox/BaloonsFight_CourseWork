using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class InfoHandler
    {
        private string _ipAdress;
        private string _port;
        private HttpListener _listener;
        private bool _stopFlag;
        public delegate string SceneJSONAction(string JSONResponse);
        public SceneJSONAction ActionWithReturn { get; set; }
        public Action<string> ActionWithoutReturn { get; set; }

        public InfoHandler(string ipAdress, string port)
        {
            _ipAdress = ipAdress;
            _port = port;
            _listener = new HttpListener();
            _stopFlag = false;
            string connectionString = "http://" + _ipAdress + ":" + port + "/";
            _listener.Prefixes.Add(connectionString);
        }
        public async void Start()
        {

            _listener.Start();
            while (!_stopFlag)
            {
                var context = await _listener.GetContextAsync();
                CheckContext(context);
            }
        }
        private async void CheckContext(HttpListenerContext context)
        {
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
                using Stream stream = response.OutputStream;
                Byte[] bytes = Encoding.UTF8.GetBytes(answer);
                await stream.WriteAsync(bytes);
                await stream.FlushAsync();
                Console.WriteLine("\nInfo Send");
            }
            else
            {
                ActionWithoutReturn(Info);
            }
        }
    }
}
