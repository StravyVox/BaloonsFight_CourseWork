using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class UIObjectsOperator.
    /// </summary>
    internal class UIObjectsOperator
    {
        /// <summary>
        /// Returns the hp.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>List&lt;GameObject&gt;.</returns>
        public static List<GameObject> ReturnHP(Balloon player)
        {
            List<GameObject> list = new List<GameObject>();

            for(int i = 0; i<player.HP;i++)
            {
                list.Add(new GameObject("Resources\\heart.png", new Vector2(-0.9f + (i * 0.1f), -0.7f), new Vector2(0.1f, 0.1f)));
            }
            return list;
        }
        /// <summary>
        /// Returns the fuel.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>List&lt;GameObject&gt;.</returns>
        public static List<GameObject> ReturnFuel(Balloon player)
        {
            List<GameObject> list = new List<GameObject>();
            int amountOfFuel = (int)(player.Fuel / 10);
            for (int i = 0; i < amountOfFuel; i++)
            {
                list.Add(new GameObject("Resources\\fuel.png", new Vector2(-0.9f + (i * 0.1f),-0.9f), new Vector2(0.1f, 0.1f)));
            }
            return list;
        }
        /// <summary>
        /// Returns the armor.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>List&lt;GameObject&gt;.</returns>
        public static List<GameObject> ReturnArmor(Balloon player)
        {
            List<GameObject> list = new List<GameObject>();
            if (player.Armor > 0)
            {
                for (int i = 0; i < player.Armor; i++)
                {
                    list.Add(new GameObject("Resources\\shield.png", new Vector2(-0.9f + (i * 0.1f),-0.8f ), new Vector2(0.1f, 0.1f)));
                }
            }
            return list;
        }

    }
}
