using GameLogicClassLibrary;
using GameNetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    internal class ServerLogic
    {
        bool _firstStart;
        SceneFrameObject _scene;
        InfoHandler _connection;

        public ServerLogic(string ip, string port)
        {
            _connection= new InfoHandler(ip, port);
            _firstStart=true;
        }
        public void RunServer()
        {
            _connection.ActionWithoutReturn = FirstStart;
            _connection.Start();
        }
        private void FirstStart(string JSONResponse)
        {
            SceneFrameObject frameObject = JsonSerializer.Deserialize<SceneFrameObject>(JSONResponse);
            if (frameObject != null && frameObject.Player == 0)
            {
                //Устанавливаем новые обработчки событий
                _connection.ActionWithoutReturn = UpdateObjects;
                _connection.ActionWithReturn = ReturnObjectsForClient;

                //Устанавливаем текущую сцену

                _scene = frameObject;
            }
        }

        private string ReturnObjectsForClient(string JSONResponse)
        {
            string result = _scene.CopyServerSceneToJSON();
            return result;
        }
        public void UpdateObjects(String JSONResponse)
        {
            SceneFrameObject frameObject = JsonSerializer.Deserialize<SceneFrameObject>(JSONResponse);
            if(frameObject.Player == 0)
            {
                _scene.Bullets = frameObject.Bullets;
                _scene.Players = frameObject.Players;
            }
            else
            {
                if (frameObject.Bullets.Length > 0)
                {
                    List<GameObject> bullets = _scene.Bullets.ToList();
                    foreach(GameObject bullet in frameObject.Bullets)
                    {
                        bullets.Add(bullet);
                    }
                    _scene.Bullets = bullets.ToArray();
                }
                _scene.Players[1] = frameObject.Players[0];
            }
            
        }
    }
}
