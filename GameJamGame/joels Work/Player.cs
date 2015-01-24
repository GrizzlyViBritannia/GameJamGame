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
		const int JUMP_POWER = -500;
		const int MOVE_LEFT = -1;
		const int MOVE_RIGHT = 1;
		const int MOVE_DOWN = 1;
		const int MOVE_UP = 1;
		const float WALKING_ACC = 1000.0f;
		const float WALKING_DEC = 700.0f;
		const float MAX_SPEED = 300.0f;

        // animation stuff (Joel)




		enum State
		{
			Walking
		}
		State currentState = State.Walking;

		public Vector2 Position = new Vector2(0, 0);

		Vector2 mDirection = new Vector2(0,1);
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

			updateMovement(gameTime, currentKeyboardState);
			updateJump(currentKeyboardState);
			checkFalling();
			updateGravity(gameTime);
			this.moveObject(mSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
			this.collisonRect = drawRect(this.drawOffset);
			if (currentKeyboardState.IsKeyDown(Keys.Space) == true)
			{
				currentState = State.Walking;
			}

			mPreviousKeyboardState = currentKeyboardState;
		}

		private void checkFalling()
		{
			if (!this.falling)
			{
				mSpeed.Y = 0;
				jumpCount = 0;
				this.isFalling(true);
			}
		}

		private void updateGravity(GameTime gameTime)
		{
			mSpeed.Y = mSpeed.Y + (this.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			//Console.WriteLine("UPDATING GRAVITY " + (this.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds) + mSpeed.Y);
		}

		private void updateWalking(GameTime gameTime, int direction)
		{
			if (direction != 0)
			{
				mSpeed.X = mSpeed.X + (direction * (WALKING_ACC * (float)gameTime.ElapsedGameTime.TotalSeconds));
				if (mSpeed.X > MAX_SPEED)
				{
					mSpeed.X = MAX_SPEED;
				}
				else if (mSpeed.X < -MAX_SPEED)
				{
					mSpeed.X = -MAX_SPEED;
				}
			}
			else
			{
				if (Math.Abs(mSpeed.X) < 10)
				{
					mSpeed.X = 0;
				} 
				else if (mSpeed.X < 0)
				{
					mSpeed.X = mSpeed.X + (WALKING_DEC * (float)gameTime.ElapsedGameTime.TotalSeconds);
				}
				else if (mSpeed.X > 0)
				{
					mSpeed.X = mSpeed.X - (WALKING_DEC * (float)gameTime.ElapsedGameTime.TotalSeconds);
				}
			}
		}

		private void updateMovement(GameTime gameTime, KeyboardState currentKeyboardState)
		{

			if (currentKeyboardState.IsKeyDown(Keys.Left) == true)
			{
				updateWalking(gameTime, MOVE_LEFT);
				Console.WriteLine("MOVE LEFT");
			}
			else if (currentKeyboardState.IsKeyDown(Keys.Right) == true)
			{
				updateWalking(gameTime, MOVE_RIGHT);
				Console.WriteLine("MOVE RIGHT");
			}
			else
			{
				updateWalking(gameTime, 0);
				Console.WriteLine("STOP MOVING");
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

			//TODO fix double jump condition.
			if (jumpCount < 2)
			{
				if (currentKeyboardState.IsKeyDown(Keys.Up) == true &&
					 mPreviousKeyboardState.IsKeyDown(Keys.Up) == false)
				{
					doJump = true;
					Console.WriteLine("TRY JUMP");
				}
			}

			return doJump;
		}

		private void jump()
		{
			jumpCount++;
			mSpeed.Y = JUMP_POWER;
			Console.WriteLine("DO JUMP");
		}

	}
}
