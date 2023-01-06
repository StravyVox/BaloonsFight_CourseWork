using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    public interface IObjectsOperator
    {
        public List<Balloon> GetPlayers();
        public List<AbstractBullet> GetBullets();
        public List<GraphicObject> ReturnObjects();
        public void UpgradePlayers(Balloon[] player);

        public void AddBonuses(AbstractBonus[] bonuses);

    }
}
