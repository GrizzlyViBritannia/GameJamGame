using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
	class CycleBlock : GameObject
	{

		int cycleNumber;

		public CycleBlock(Texture2D texture, Vector2 pos, Color colour, int cycle)
		{
			this.texture = texture;
			this.colour = colour;
			this.centerPosition = pos;
			cycleNumber = cycle;
			drawSize = new Vector2(this.texture.Width, this.texture.Height);
			this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
		}

		public override void update(GameTime gameTime)
		{
			checkForCollisions();
			run();
			updateBlocks();
		}

		private void updateBlocks()
		{
			if (cycleNumber == Game1.getCycle())
			{
				this.collidable = true;
				this.colour.A = 255;
			}
			else
			{
				this.collidable = false;
				this.colour.A = 1;
			}
		}

		public int getCycle()
		{
			return cycleNumber;
		}
	}
}
