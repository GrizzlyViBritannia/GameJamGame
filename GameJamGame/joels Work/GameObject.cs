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
	class GameObject
	{
		// logic variables
		protected Vector2 centerPosition;
		protected Rectangle collisonRect;

		protected bool movable;
		protected bool collidable;

		// draw variable
		protected Color colour;
        protected Texture2D texture;

		// private functions:

		private Rectangle drawRect(Vector2 input)
		{
			return new Rectangle((int)(input.X - (int)(texture.Width / 2)), (int)(input.Y - (int)(texture.Height / 2)), texture.Width, texture.Height);
		}

		// public functions:
        public GameObject()
        {

        }
        public GameObject(Texture2D texture, Vector2 pos, Color colour)
        {
            this.texture = texture;
            this.centerPosition = pos;
            this.colour = colour;

            this.collisonRect = drawRect(centerPosition);
        }


		public void moveObject(Vector2 input)
		{
			this.centerPosition += input;
		}

		// main logic-draw functions

        public void update(GameTime gameTime)
		{

		}
		public void draw(SpriteBatch SB)
		{
            SB.Draw(this.texture, this.drawRect(this.centerPosition), this.colour);
        }
        public void load (Texture2D texture)
        {
            this.texture = texture;
		}

		// get-set functions:
		public bool isMovable()
		{
			return this.movable;
		}
		public bool isCollidable()
		{
			return this.collidable;
		}

		public Rectangle getCollisionRect()
		{
			return this.collisonRect;
		}

		public Vector2 getCenterPosition()
		{
			return this.centerPosition;
		}


	}
}
