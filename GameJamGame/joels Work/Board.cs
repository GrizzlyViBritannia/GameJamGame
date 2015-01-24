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
	class Board
	{
		Texture2D currentBackGround;
		Rectangle currentDrawRect;
		List<GameObject> gameObjectList;
        Player playerPointer;
		// constructor
		public Board()
		{

		}

		// private functions:
		private void checkCollision(GameObject object1, GameObject object2)
		{
			/*
			 * Chris, produce a function to go in the Board class (not yet created).
			 * the functions will take two objects, check if they are colliding, and 
			 * fix the collision via the "moveObject(Vector2)" function.
			 * this function takes a Vector2 variable and will move the object by 
			 * said vector
			 */

			//if rectangle1 and rectangle2 are colliding
			if (object1.getCollisionRect().Intersects(object2.getCollisionRect()))
			{
				//if rectangle1 is movable move it away from rectangle2
				if (object1.isMovable())
				{
					object1.moveObject(new Vector2(object2.getCenterPosition().X - object1.getCenterPosition().X, object2.getCenterPosition().Y - object1.getCenterPosition().Y));
				}
				//if rectangle2 is movable move it away from rectangle1
				if (object2.isMovable())
				{
					object2.moveObject(new Vector2(object1.getCenterPosition().X - object2.getCenterPosition().X, object1.getCenterPosition().Y - object2.getCenterPosition().Y));
				}
			}

		}

        // public functions:
        public void endLevel(Player player)
        {

        }

        public void buildBoard(Level level, Player player)
        {
            this.currentBackGround = level.backGround;
            this.gameObjectList.Clear();
            this.gameObjectList.Add(player);
            this.gameObjectList.AddRange(level.getObjectList());
        }


		// public logic-draw functions
		public void update(GameTime gameTime)
		{
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                buildBoard(Game1.levelList[0], (Player)this.gameObjectList[0]);
            }

			foreach (GameObject i in gameObjectList)
			{
				i.update(gameTime);
			}
			foreach (GameObject i in gameObjectList)
			{
				foreach (GameObject j in gameObjectList)
				{
					if (i != j)
					{
						this.checkCollision(i, j);
					}
				}
			}

		}

		public void load(int objectNumber)
		{
			this.currentBackGround = Game1.backGroundPlaceHolderSave;
			this.currentDrawRect = new Rectangle(0, 0, 500, 500);
			gameObjectList = new List<GameObject>();
			gameObjectList.Add(new Player(Game1.playerTextureSave, new Vector2(0, 0), Color.White)); // player will always be index 0
			gameObjectList[0].load(Game1.playerTextureSave);
            playerPointer = (Player)gameObjectList[0];
            
            gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(200, 200),Color.White));
            gameObjectList[1].load(Game1.objectPlaceHolderSave);
			
            for (int i = 0; i < objectNumber; i++)
			{
				gameObjectList.Add(new GameObject(GameJamGame.Game1.objectPlaceHolderSave, new Vector2(Game1.rnd.Next(10, 250), Game1.rnd.Next(10, 490)), Color.White));
				gameObjectList[i + 1].load(Game1.objectPlaceHolderSave);
			}
		}


		public void draw(SpriteBatch SB)
		{
			SB.Draw(this.currentBackGround, this.currentDrawRect, Color.White);
			foreach (GameObject i in this.gameObjectList)
			{
				i.draw(SB);
			}





		}
	}
}
