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

        protected bool drawable = true;

		protected int state; // 1 is INIT	2 is INTERMEDIATE	3 is DEAD

		// draw variable
		protected Color colour;
        protected Texture2D texture;
        protected Vector2 drawOffset = Vector2.Zero;
		protected Vector2 mSpeed = Vector2.Zero;
        protected int spriteState;
        protected Vector2 drawSize;


		// private functions:

        public Rectangle drawRect(Vector2 offset)
        {
            Vector2 drawPos = new Vector2((int)(this.centerPosition.X - (drawSize.X / 2)),
                                          (int)(this.centerPosition.Y - (drawSize.Y / 2)));
            drawPos += this.drawOffset + offset;
            if (drawSize == Vector2.Zero)
            {
                return new Rectangle(
                    (int)drawPos.X,
                    (int)drawPos.Y,
                    texture.Width,
                    texture.Height);
            }
            else
            {
                return new Rectangle(
                    (int)drawPos.X,
                    (int)drawPos.Y,
                    (int)drawSize.X,
                    (int)drawSize.Y);
            }
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
            drawSize = new Vector2(this.texture.Width,this.texture.Height);
            this.collisonRect = drawRect(Vector2.Zero);
			this.movable = false;
        }


		public void moveObject(Vector2 input)
		{
			this.centerPosition += input;
			this.collisonRect = drawRect(this.drawOffset);
		}

		// main logic-draw functions

        public virtual void update(GameTime gameTime)
		{
			
		}
		public virtual void draw(SpriteBatch SB, Vector2 offset)
		{
            if (drawable)
                //SB.Draw()
                SB.Draw(this.texture, this.drawRect(offset), this.colour);
        }
        public void load (Texture2D texture)
        {
            this.texture = texture;
		}

		// get-set functions:
        
        public GameObject clone()
        {
            return (GameObject)MemberwiseClone();
        }
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
        public void setPosition(Vector2 pos)
        {
            this.centerPosition = pos;
        }

		public Vector2 getSpeed()
		{
			return this.mSpeed;
		}

		public int getState()
		{
			return this.state;
		}
	}
}
