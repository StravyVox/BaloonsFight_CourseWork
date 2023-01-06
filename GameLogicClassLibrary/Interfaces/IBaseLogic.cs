using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    public interface IBaseLogic
    {
        public List<GameObject> GameObjects { get; set; }
        public List<AbstractBullet> Bullets { get; set; }
        public List<Balloon> Players { get; set; }
        public void FrameLogic(float DeltaTime);//Производит базовую логику на кадре. Вызывает методы кадра у объектов, проверяет попадание пуль
        public void MovePlayer(float DeltaTime);
        public void Shoot();
        public void GameOver(GameObject obj);
    }
}
