using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
	class MoveBlock : GameObject
	{

		int moveDirection;
		float moveSpeed = 1.0f;

		public MoveBlock(Texture2D texture, Vector2 pos, Color colour, int direction)
		{
			this.texture = texture;
			this.colour = colour;
			this.centerPosition = pos;
			moveDirection = direction;
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

		protected override void stillColliding()
		{
			Vector2 resultVector = Vector2.Zero;
			if (moveDirection == 0)
            {
                resultVector = new Vector2(0, 1);
            }
            else if (moveDirection == 1)
            {
                resultVector = new Vector2(1, 0);
            }
			else if (moveDirection == 2)
            {
                resultVector = new Vector2(0, -1);
            }
			else if (moveDirection == 3)
            {
                resultVector = new Vector2(-1, 0);
            }
			this.moveObject(resultVector * moveSpeed);
		}
	}
}
