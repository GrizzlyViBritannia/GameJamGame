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

		enum State
		{
			Walking,
			Jumping
		}
		State currentState = State.Walking;

		Vector2 mDirection = Vector2.Zero;
		Vector2 mSpeed = Vector2.Zero;

		KeyboardState mPreviousKeyboardState;

		public void Update(GameTime theGameTime)
		{
			//KeyboardState aCurrentKeyboardState = Keyboard.GetState();

			//UpdateMovement(aCurrentKeyboardState);

			//mPreviousKeyboardState = aCurrentKeyboardState;

			//base.Update(theGameTime, mSpeed, mDirection);
		}

		private void UpdateMovement(KeyboardState currentKeyboardState)
		{


		}
	}
}
