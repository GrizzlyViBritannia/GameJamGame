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


namespace GameJamGame.joels_Work
{
    class invisibleBlock : GameObject
    {

        public invisibleBlock(Texture2D texture, Rectangle region, Color colour)
		{
			this.texture = texture;
			this.colour = colour;
            this.centerPosition = new Vector2(region.X + (region.Width/2), region.Y + (region.Height/2));
            drawSize = new Vector2(region.Width, region.Height);
			this.collisonRect = drawRect(Vector2.Zero);
            this.drawable = true;
			this.movable = false;
			this.colliding = false;
			this.state = 0;
		}

    }
}
