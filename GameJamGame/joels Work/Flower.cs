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
    class Flower : GameObject
    {
        public Flower(Texture2D texture, Vector2 pos, Color colour)
        {
            this.texture = texture;
            this.colour = Color.White;
            this.centerPosition = pos;
            drawSize = new Vector2(this.texture.Width,this.texture.Height);
            this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
        }

        public override void update(GameTime gameTime)
        {
            checkForCollisions();
            run();
        }

        protected override void collision()
        {
            if (collidable)
            {
                Game1.swapCompleteBlocks();
                this.drawable = false;
            }
            this.collidable = false;

        }

    }
}
