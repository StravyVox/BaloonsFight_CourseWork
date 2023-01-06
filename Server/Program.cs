
using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;
using GameNetLibrary;
using Server;
using System.Text.Json;

namespace ServerProgram
{
    public class Program
    {
        public static void Main()
        {
            ServerLogic server = new ServerLogic("127.0.0.1", "8888");
            server.RunServer();
            Console.WriteLine("Server started");
        }
    }
}