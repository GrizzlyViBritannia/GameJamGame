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
	public class GameObject
	{
		// logic variables
		protected Vector2 centerPosition;
		protected Rectangle collisonRect;
		protected float gravity = 1000.0f;

		protected bool movable;
		protected bool collidable;
		protected bool falling;
		protected bool colliding;

		// draw variable
		protected Color colour;
        protected Texture2D texture;
        protected Vector2 drawOffset = Vector2.Zero;

		// private functions:

        public Rectangle drawRect(Vector2 offset)
        {
            Vector2 drawPos = new Vector2((int)(this.centerPosition.X - (texture.Width / 2)),
                                          (int)(this.centerPosition.Y - (texture.Height / 2)));
            drawPos += this.drawOffset + offset;

            return new Rectangle(
                (int)drawPos.X,
                (int)drawPos.Y,
                texture.Width, 
                texture.Height);
        }

		// public functions:
        public GameObject()
        {

        }
        public GameObject(Texture2D texture, Vector2 pos, Color colour)
        {
            this.texture = texture;
            this.colour = colour;
            this.centerPosition = pos;
            this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
        }


		public void moveObject(Vector2 input)
		{
			this.centerPosition += input;
		}

		// main logic-draw functions

        public virtual void update(GameTime gameTime)
		{
			
		}
		public void draw(SpriteBatch SB, Vector2 offset)
		{
            SB.Draw(this.texture, this.drawRect(offset), this.colour);
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

		public bool isColliding()
		{
			return this.colliding;
		}

		public void isColliding(bool colliding)
		{
			this.colliding = colliding;
		}

		public void isFalling(bool falling)
		{
			this.falling = falling;
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
