using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogicClassLibrary;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class FrameWorker.
    /// </summary>
    public static class FrameWorker
    {
        /// <summary>
        /// Frames the move.
        /// </summary>
        /// <param name="DeltaTime">The delta time.</param>
        /// <param name="objects">The objects.</param>
        public static void FrameMove(float DeltaTime, List<GameObject> objects)
        {
            foreach(IFrame obj in objects)
            {
                obj.Frame(DeltaTime);
            }
        }
        /// <summary>
        /// Frames the check collission.
        /// </summary>
        /// <param name="bullets">The bullets.</param>
        /// <param name="takers">The takers.</param>
        public static void FrameCheckCollission( List<AbstractBullet> bullets , List<Balloon> takers)
        {
            
            Dictionary<int, int> resultOf = CollissionChecker.CheckCollissionBetween(bullets.ToList<GameObject>(), takers.ToList<GameObject>());
            if(resultOf.Count > 0 )
            {
                foreach(var result in resultOf)
                {
                    (takers[result.Value]).TakeDamage(((AbstractBullet)(bullets[result.Key])).Damage);
                    if ((takers[result.Value]).HP <= 0)
                    {
                        takers[result.Value].Dispose();
                        takers.RemoveAt(result.Value);
                    }
                    bullets.RemoveAt(result.Key);
                }
            }
        }
       
    }
}
