using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class BonusCollissionOperator.
    /// </summary>
    public static class BonusCollissionOperator
    {
        /// <summary>
        /// Bonuses the check collission.
        /// </summary>
        /// <param name="bullets">The bullets.</param>
        /// <param name="bonuses">The bonuses.</param>
        /// <param name="players">The players.</param>
        public static void BonusCheckCollission(List<AbstractBullet> bullets, List<AbstractBonus> bonuses, List<Balloon> players)
        {
            Dictionary<int, int> result = CollissionChecker.CheckCollissionBetween(bullets.ToList<GameObject>(), bonuses.ToList<GameObject>());
            if (result != null)
            {
                foreach (var collission in result)
                {
                    switch (CheckBonusAffect(bonuses[collission.Value]))
                    {
                        case 0:
                            if (bullets[collission.Key].Direction > 0)
                                players[0] = DecoratePlayer(bonuses[collission.Value], players[0]);
                            else
                            {
                                players[1] = DecoratePlayer(bonuses[collission.Value], players[1]);
                            }
                            break;
                        case 1:
                            bullets[collission.Key] = DecorateBullet(bonuses[collission.Value], bullets[collission.Key]);
                            break;
                    }
                    bonuses.RemoveAt(collission.Value);
                }
            }
        }
        /// <summary>
        /// Checks the bonus affect.
        /// </summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>System.Int32.</returns>
        private static int CheckBonusAffect(AbstractBonus bonus)
        {
            switch (bonus.Description)
            {
                case "health": return 0;
                case "armor": return 0;
                case "bigbullet": return 1;
                case "fuel": return 0;
                case "speedbullet": return 1;

            }
            return 1;
        }
        /// <summary>
        /// Decorates the bullet.
        /// </summary>
        /// <param name="bonus">The bonus.</param>
        /// <param name="bullet">The bullet.</param>
        /// <returns>AbstractBullet.</returns>
        private static AbstractBullet DecorateBullet(AbstractBonus bonus, AbstractBullet bullet)
        {
          
             switch(bonus.Description)
            {
                case "bigbullet": return new BigBullet(bullet);
                case "speedbullet": return new FastBullet(bullet);
                default:return bullet;
            }
        }
        /// <summary>
        /// Decorates the player.
        /// </summary>
        /// <param name="bonus">The bonus.</param>
        /// <param name="player">The player.</param>
        /// <returns>Balloon.</returns>
        private static Balloon DecoratePlayer(AbstractBonus bonus, Balloon player)
        {
            switch (bonus.Description)
            {
                case "armor": player.Armor += 1;
                    return player;
                case "fuel": player.Fuel += 50;
                    return player;
                case "health": player.HP+= 1;
                    return player;
                default:return player;
            }
        }
    }
}
