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
		const int JUMP_POWER = -350;
		const int MOVE_LEFT = -1;
		const int MOVE_RIGHT = 1;
		const int MOVE_DOWN = 1;
		const int MOVE_UP = 1;
		const float WALKING_ACC = 2000.0f;
		const float WALKING_DEC = 2000.0f;
		const float MAX_SPEED_WALKING = 150.0f;
		const float MAX_SPEED_JUMPING = 75.0f;

        int animationTimer = 0;

		// animation stuff (Joel)




		enum State
		{
            Standing,
            WalkingRight,
			WalkingLeft,
			Jumping
		}
        State currentState = State.Standing;

		//public Vector2 Position = new Vector2(0, 0);

		Vector2 mDirection = new Vector2(0, 1);
		Vector2 jumpStartingPosition = Vector2.Zero;
        int animationState;

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
            this.drawSize = new Vector2(30, 42);
			this.collisonRect = drawRect(this.drawOffset);
		}

		public override void update(GameTime gameTime)
		{


			KeyboardState currentKeyboardState = Keyboard.GetState();

			updateMovement(gameTime, currentKeyboardState);
			checkFalling();
			updateJump(currentKeyboardState);
			updateGravity(gameTime);
			this.moveObject(mSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
			this.collisonRect = drawRect(this.drawOffset);
			if (currentKeyboardState.IsKeyDown(Keys.Space) == true)
			{
				//currentState = State.;
			}

			mPreviousKeyboardState = currentKeyboardState;

            // state checking
            //if (this.falling && (mSpeed.Y > 0 && mSpeed.Y < 0))
            //{
            //    this.currentState = State.Jumping;
            //}
            //else if (mSpeed.X > 0)
            //{
            //    this.currentState = State.WalkingRight;
            //}
            //else if (mSpeed.X < 0)
            //{
            //    this.currentState = State.WalkingLeft;
            //}
            //else
            //{
            //    this.currentState = State.Standing;
            //}
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
			float currentMax;
            if (currentState == State.WalkingLeft || currentState == State.WalkingRight)
			{
				currentMax = MAX_SPEED_WALKING;
			}
			else if (currentState == State.Jumping)
			{
				currentMax = MAX_SPEED_JUMPING;
			}
			else
			{
				currentMax = MAX_SPEED_WALKING;
			}

			if (direction != 0)
			{
				mSpeed.X = mSpeed.X + (direction * (WALKING_ACC * (float)gameTime.ElapsedGameTime.TotalSeconds));
				if (mSpeed.X > currentMax)
				{
					mSpeed.X = currentMax;
				}
				else if (mSpeed.X < -currentMax)
				{
					mSpeed.X = -currentMax;
				}
			}
			else
			{
				if (Math.Abs(mSpeed.X) < 10)
				{
					mSpeed.X = 0;
                    currentState = State.Standing;
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
                if(currentState != State.Jumping)
                    currentState = State.WalkingLeft;
			}
			else if (currentKeyboardState.IsKeyDown(Keys.Right) == true)
			{
				updateWalking(gameTime, MOVE_RIGHT);
                if (currentState != State.Jumping)
                    currentState = State.WalkingRight;
			}
			else
			{
				updateWalking(gameTime, 0);
                if (currentState != State.Jumping)
                    currentState = State.Standing;
			}
		}

		private void updateJump(KeyboardState currentKeyboardState)
		{
			if (jumpInit(currentKeyboardState) == true)
			{
				jump();
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
				}
			}

			return doJump;
		}


        //
        //
        //
        //

        public override void draw(SpriteBatch SB, Vector2 offset)
        {
            SB.Draw(
                this.texture,
                new Vector2(this.drawRect(this.drawOffset).X, this.drawRect(this.drawOffset).Y),
                new Rectangle(
                    this.animationState * (int)this.drawSize.X,
                    (int)this.currentState * (int)this.drawSize.Y, 
                    (int)this.drawSize.X, 
                    (int)this.drawSize.Y),
                Color.White);
            
            animationTimer++;
            if (animationTimer > 10)
            {
                this.animationState++;
                if (this.animationState > 2)
                {
                    this.animationState = 0;
                }
                animationTimer = 0;
            }
        }

		private void jump()
		{
			jumpCount++;
			currentState = State.Jumping;
			mSpeed.Y = JUMP_POWER;
			Console.WriteLine("DO JUMP");
		}


		internal void setPosition(int p1, int p2)
		{
			throw new NotImplementedException();
		}
	}
}
