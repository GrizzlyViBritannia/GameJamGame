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
		const int MOVE_LEFT = -1;
		const int MOVE_RIGHT = 1;
		const int MOVE_DOWN = -1;
		const int MOVE_UP = 1;


		enum State
		{
			Walking,
			Jumping,
			Falling
		}
		State currentState = State.Walking;

		public Vector2 Position = new Vector2(0, 0);

		Vector2 mDirection = Vector2.Zero;
		Vector2 mSpeed = Vector2.Zero;
		Vector2 jumpStartingPosition = Vector2.Zero;

		KeyboardState mPreviousKeyboardState;

		public void update(GameTime theGameTime)
		{
			KeyboardState currentKeyboardState = Keyboard.GetState();

			updateMovement(currentKeyboardState);

			mPreviousKeyboardState = currentKeyboardState;
		}

		private void updateMovement(KeyboardState currentKeyboardState)
		{
			if (currentState == State.Walking)
			{
				mSpeed = Vector2.Zero;
				mDirection = Vector2.Zero;

				if (currentKeyboardState.IsKeyDown(Keys.Left) == true || currentKeyboardState.IsKeyDown(Keys.A) == true)
				{
					mSpeed.X = WALKING_SPEED;
					mDirection.X = MOVE_LEFT;
				}
				else if (currentKeyboardState.IsKeyDown(Keys.Right) == true || currentKeyboardState.IsKeyDown(Keys.D) == true)
				{
					mSpeed.X = WALKING_SPEED;
					mDirection.X = MOVE_RIGHT;
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

			if (currentKeyboardState.IsKeyDown(Keys.Space) == true &&
				   mPreviousKeyboardState.IsKeyDown(Keys.Space) == false)
			{
				doJump = true;
			}
			else if (currentKeyboardState.IsKeyDown(Keys.W) == true &&
				 mPreviousKeyboardState.IsKeyDown(Keys.W) == false)
			{
				doJump = true;
			}
			else if (currentKeyboardState.IsKeyDown(Keys.Up) == true &&
				 mPreviousKeyboardState.IsKeyDown(Keys.Up) == false)
			{
				doJump = true;
			}

			return doJump;
		}

		private void jump()
		{
			if (currentState != State.Jumping)
			{
				currentState = State.Jumping;
				jumpStartingPosition = Position;
				mDirection.Y = MOVE_UP;
				mSpeed = new Vector2(WALKING_SPEED, WALKING_SPEED);
			}
		}

	}
}
