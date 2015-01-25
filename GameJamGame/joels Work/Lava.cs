using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
	class Lava : GameObject
	{
		public Lava(Texture2D texture, Vector2 pos, Color colour)
		{
			this.texture = texture;
			this.colour = colour;
			this.centerPosition = pos;
			drawSize = new Vector2(this.texture.Width, this.texture.Height);
			this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
		}

		public override void update(GameTime gameTime)
		{
			checkForCollisions();
			run();
		}

		protected override void collision()
		{

		}


	}
}
