using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
	class Shatter : GameObject
	{
        public Shatter(Texture2D texture, Vector2 pos, Color colour)
        {
            this.texture = texture;
            this.colour = colour;
            this.centerPosition = pos;
            this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
			this.state = 0;
        }

		public override void update(GameTime gameTime)
		{
            if (state >= 5)
            {
                int x = 0; // destroy the block
            }
			if (colliding)
			{
				state = 1;
			}
			else if (state >= 1)
			{
				state ++;
			}
		}

        // block colide event

        // block is colliding

        // block stops colliding

	}
}
