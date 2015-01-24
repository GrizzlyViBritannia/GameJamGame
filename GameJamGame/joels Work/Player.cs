#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
namespace GameJamGame.joels_Work
{
	class Player : GameObject
	{

		const int WALKING_SPEED = 160;
		const int JUMP_POWER = 10;
		const int MOVE_LEFT = -1;
		const int MOVE_RIGHT = 1;
		const int MOVE_DOWN = -1;
		const int MOVE_UP = 1;

        // animation stuff (Joel)




		enum State
		{
			Walking,
			Jumping,
			Falling
		}
		State currentState = State.Walking;

		//public Vector2 Position = new Vector2(0, 0);

		Vector2 mDirection = Vector2.Zero;
		Vector2 mSpeed = Vector2.Zero;
		Vector2 jumpStartingPosition = Vector2.Zero;

		int jumpCount = 0;

		KeyboardState mPreviousKeyboardState;

        public Player()
		{

        }
        public Player(Texture2D texture, Vector2 pos, Color colour)
        {
            this.texture = texture;
            this.centerPosition = pos;
            this.colour = colour;
			this.movable = true;
			this.collisonRect = drawRect(this.drawOffset);
        }

		public override void update(GameTime gameTime)
		{
			KeyboardState currentKeyboardState = Keyboard.GetState();

			updateMovement(currentKeyboardState);
			updateJump(currentKeyboardState);
			updateGravity(gameTime);
			this.moveObject(mDirection * mSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
			this.collisonRect = drawRect(this.drawOffset);
			if (currentKeyboardState.IsKeyDown(Keys.Space) == true)
			{
				currentState = State.Walking;
			}

			mPreviousKeyboardState = currentKeyboardState;
		}

		private void updateGravity(GameTime gameTime)
		{
			mSpeed.Y =+ (this.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds); 
		}

		private void updateMovement(KeyboardState currentKeyboardState)
		{
			if (currentState == State.Walking)
			{
				mSpeed.X = 0;
				mDirection.X = 0;

				if (currentKeyboardState.IsKeyDown(Keys.Left) == true)
				{
					mSpeed.X = WALKING_SPEED;
					mDirection.X = MOVE_LEFT;
					Console.WriteLine("MOVE LEFT");
				}
				else if (currentKeyboardState.IsKeyDown(Keys.Right) == true)
				{
					mSpeed.X = WALKING_SPEED;
					mDirection.X = MOVE_RIGHT;
					Console.WriteLine("MOVE RIGHT");
				}
			}
		}

		private void updateJump(KeyboardState currentKeyboardState)
		{
			if (currentState == State.Walking)
			{
				if (jumpInit(currentKeyboardState) == true)
				{
					jump();
				}
			}
		}

		private bool jumpInit(KeyboardState currentKeyboardState)
		{
			bool doJump = false;

			if (jumpCount < 2)
			{
				if (currentKeyboardState.IsKeyDown(Keys.Up) == true &&
					 mPreviousKeyboardState.IsKeyDown(Keys.Up) == false)
				{
					doJump = true;
				}
			}

			return doJump;
		}

		private void jump()
		{
			if (currentState != State.Jumping)
			{
				currentState = State.Jumping;
				jumpCount++;
				mDirection.Y = MOVE_UP;
				mSpeed.Y = JUMP_POWER;
			}
		}


        internal void setPosition(int p1, int p2)
        {
            throw new NotImplementedException();
        }
    }
}
