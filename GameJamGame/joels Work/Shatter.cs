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
			this.state = 1;
        }

		public virtual void update(GameTime gameTime)
		{
			if (colliding)
			{
				state = 2;
			}
			else if (state == 2)
			{
				state = 3;
				collidable = false;
			}
		}
	}
}
