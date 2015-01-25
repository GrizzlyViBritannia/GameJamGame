using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
	class CompleteBlock : GameObject
	{
        int direction;
        public bool visable;
		public CompleteBlock(Texture2D texture, Vector2 pos, Color colour, int direction, bool visable)
		{
            this.collidable = false;
            this.visable = visable;
			this.texture = texture;
			this.colour = colour;
			this.centerPosition = pos;
            this.direction = direction;
			drawSize = new Vector2(50, 50);
			this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
		}

		public override void update(GameTime gameTime)
		{
            if (visable)
            {
                checkForCollisions();
                run();
            }
		}

        public override void draw(SpriteBatch SB, Vector2 offset)
        {
            if (visable)
                base.draw(SB, offset);
        }

		protected override void collision()
		{
            if (visable)
                Game1.endLevel(direction);
		}

	}
}
