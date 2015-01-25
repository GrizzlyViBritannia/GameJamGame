using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJamGame.joels_Work
{
    class startGameBlock : GameObject
    {
        public startGameBlock(Texture2D texture, Vector2 pos, Color colour)
		{
            this.collidable = false;
			this.texture = texture;
			this.colour = colour;
			this.centerPosition = pos;
			drawSize = new Vector2(50, 50);
			this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
			this.colliding = false;
		}

		public override void update(GameTime gameTime)
		{
            this.collidable = true;
            checkForCollisions();
            run();
		}

        public override void draw(SpriteBatch SB, Vector2 offset)
        {
            base.draw(SB, offset);
        }

		protected override void collision()
		{
            Game1.endLevel(1);
		}
    }
}
