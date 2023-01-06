using GameLogicClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace GameNetLibrary
{
    /// <summary>
    /// Class BonusGenerator
    /// </summary>
    internal class BonusGenerator
    {
        /// <summary>
        /// The rand function
        /// </summary>
        Random _randFunc;
        /// <summary>
        /// Initializes a new instance of the <see cref="BonusGenerator"/> class.
        /// </summary>
        public BonusGenerator()
        {
            _randFunc = new Random();
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns>AbstractBonus.</returns>
        public AbstractBonus Generate()
        {
            AbstractBonus bonus;
            int bonusType = _randFunc.Next(0, 5);
            float bonusXPosition = (_randFunc.Next(1, 3) == 1 ? 1 : -1);
            bonusXPosition*=(float)(_randFunc.NextDouble()/2);
            switch (bonusType)
            {
                case 0:
                    return bonus = new ArmorBonusCreator().CreateBonus(new Vector2(bonusXPosition, 0.9f));
                case 1:
                    return bonus = new HealthBonusCreator().CreateBonus(new Vector2(bonusXPosition, 0.9f));
                case 2:
                    return bonus = new BigBulletBonusCreator().CreateBonus(new Vector2(bonusXPosition, 0.9f));
                case 3:
                    return bonus = new FuelBonusCreator().CreateBonus(new Vector2(bonusXPosition, 0.9f));
                case 4:
                    return bonus = new SpeedBulletBonusCreator().CreateBonus(new Vector2(bonusXPosition, 0.9f));
            }
            return null;
        }
    }
}
