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
		Texture2D texture1;
		Texture2D texture2;

		public CycleBlock(Texture2D texture, Texture2D alphaTexture, Vector2 pos, Color colour, int cycle)
		{
			this.texture = texture;
			this.texture1 = texture;
			this.texture2 = alphaTexture;
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
				this.texture = texture1;
			}
			else
			{
				this.collidable = false;
				this.texture = texture2;
			}
		}

		public int getCycle()
		{
			return cycleNumber;
		}
	}
}
