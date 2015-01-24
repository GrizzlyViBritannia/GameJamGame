#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace GameJamGame.Chris_Work
{
    class Collison
    {
        public Vector2 CheckCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            return new Vector2(rectangle1.X - rectangle2.X, rectangle1.Y - rectangle2.Y);
        }
    }
}
