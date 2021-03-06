﻿using Microsoft.Xna.Framework;
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
            drawSize = new Vector2(this.texture.Width, this.texture.Height);
			this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
			this.state = 0;
		}

		public override void update(GameTime gameTime)
		{
			checkForCollisions();
			run();
		}

		protected override void stoppedColliding()
		{
			this.deletable = true;
		}

	}
}
