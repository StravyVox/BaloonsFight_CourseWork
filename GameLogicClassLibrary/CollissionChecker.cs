using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class CollissionChecker.
    /// </summary>
    public static class CollissionChecker
    {
        /// <summary>
        /// Checks the collission between.
        /// </summary>
        /// <param name="collissionObjects">The collission objects.</param>
        /// <param name="collissionedObjects">The collissioned objects.</param>
        /// <returns>Dictionary&lt;System.Int32, System.Int32&gt;.</returns>
        public static Dictionary<int,int> CheckCollissionBetween(List<GameObject> collissionObjects, List<GameObject> collissionedObjects)
        {
            Dictionary<int, int> result = new Dictionary<int, int>(); 
            for(int i =0; i < collissionObjects.Count; i++)
            {
                for(int j=0; j<collissionedObjects.Count; j++)
                {
                    if (IsObjectTouchedObject(collissionObjects[i], collissionedObjects[j]))
                    {
                        try
                        {
                            result.Add(i, j);
                        }
                        catch { }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Determines whether [is object touched object] [the specified FRST object].
        /// </summary>
        /// <param name="frstObj">The FRST object.</param>
        /// <param name="secObj">The sec object.</param>
        /// <returns><c>true</c> if [is object touched object] [the specified FRST object]; otherwise, <c>false</c>.</returns>
        private static bool IsObjectTouchedObject(GameObject frstObj, GameObject secObj)
        {
            if ((frstObj.Position.X >= secObj.Position.X - (secObj.Size.X /2)) && (frstObj.Position.X <= secObj.Position.X + (secObj.Size.X / 2)))
            {
                if ((frstObj.Position.Y <= secObj.Position.Y + (secObj.Size.Y/2)) && (frstObj.Position.Y >= secObj.Position.Y - (secObj.Size.Y/2)))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
