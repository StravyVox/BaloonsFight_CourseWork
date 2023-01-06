using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameLogicClassLibrary
{
    /// <summary>
    /// Class ObjectMover.
    /// </summary>
    public static class ObjectMover
    {

        /// <summary>
        /// Moves the object to point.
        /// </summary>
        /// <param name="objectToMove">The object to move.</param>
        /// <param name="point">The point.</param>
        /// <param name="speed">The speed.</param>
        public static void MoveObjectToPoint(GameObject objectToMove,Vector2 point, float speed)
        {
            Vector2 MovePosition = new Vector2(objectToMove.Position.X + (point.X * speed), objectToMove.Position.Y + (point.Y * speed));
            objectToMove.Position = MovePosition;

        }
        /// <summary>
        /// Moves the object by x.
        /// </summary>
        /// <param name="objectToMove">The object to move.</param>
        /// <param name="XOffset">The x offset.</param>
        /// <param name="speed">The speed.</param>
        public static void MoveObjectByX(GameObject objectToMove, float XOffset, float speed)
        {

            Vector2 MovePosition = new Vector2(objectToMove.Position.X + (XOffset * speed), objectToMove.Position.Y);
            objectToMove.Position = MovePosition;
        }
        /// <summary>
        /// Moves the object by y.
        /// </summary>
        /// <param name="objectToMove">The object to move.</param>
        /// <param name="YOffset">The y offset.</param>
        /// <param name="speed">The speed.</param>
        public static void MoveObjectByY(GameObject objectToMove, float YOffset, float speed)
        {

            Vector2 MovePosition = new Vector2(objectToMove.Position.X, objectToMove.Position.Y + (YOffset * speed));
            objectToMove.Position = MovePosition;
        }

    }
}
