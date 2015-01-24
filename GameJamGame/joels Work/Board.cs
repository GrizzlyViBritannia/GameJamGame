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

        String updateState = "update";


        // animation stuff:
        Vector2 boardOffset = Vector2.Zero;
        Vector2 directionOffset = Vector2.Zero;
        float speed = 1.0f;
        Vector2 endPoint = Vector2.Zero;
		// constructor
		public Board()
		{

		}

		// private functions:
		private bool checkCollision(GameObject object1, GameObject object2)
		{
			/*
			 * Chris, produce a function to go in the Board class (not yet created).
			 * the functions will take two objects, check if they are colliding, and 
			 * fix the collision via the "moveObject(Vector2)" function.
			 * this function takes a Vector2 variable and will move the object by 
			 * said vector
			 */

			Rectangle o1Rect = object1.getCollisionRect();
			Rectangle o2Rect = object2.getCollisionRect();
			int returnIndex = -1;

			//if rectangle1 and rectangle2 are colliding
			if (o1Rect.Intersects(o2Rect))
			{
				//if rectangle1 is movable move it away from rectangle2
				if (object1.isMovable())
				{
					float[] intersect = new float[4];

					if (o1Rect.Bottom > o2Rect.Top && o1Rect.Bottom < o2Rect.Bottom)
					{
						intersect[0] = o2Rect.Top - o1Rect.Bottom;
					}

					if (o1Rect.Left < o2Rect.Right && o1Rect.Left > o2Rect.Left)
					{
						intersect[1] = o2Rect.Right - o1Rect.Left;
					}

					if (o1Rect.Top < o2Rect.Bottom && o1Rect.Top > o2Rect.Top)
					{
						intersect[2] = o2Rect.Bottom - o1Rect.Top;
					}

					if (o1Rect.Right > o2Rect.Left && o1Rect.Right < o2Rect.Right)
					{
						intersect[3] = o2Rect.Left - o1Rect.Right;
					}

					int index = 0, count = 0;

					foreach (float intersection in intersect)
					{
						if (Math.Abs(intersection) < Math.Abs(intersect[index]) && Math.Abs(intersection) != 0)
						{
							index = count;
						}
						count++;
					}

					Vector2 newVector;

					if (index % 2 == 0)
					{
						newVector = new Vector2(0, intersect[index]);
					}
					else
					{
						newVector = new Vector2(intersect[index], 0);
					}

					if (index == 0)
					{
						object1.isFalling(false);
					}

					object1.moveObject(newVector);
				}
				//if rectangle2 is movable move it away from rectangle1
				//if (object2.isMovable())
				//{
				//	object2.moveObject(new Vector2(object1.getCenterPosition().X - object2.getCenterPosition().X, object1.getCenterPosition().Y - object2.getCenterPosition().Y));
				//}

				return true;
			}
			return false;
		}

        private void declareTransition(Vector2 direction, Vector2 endCornerPoint)
        {
            boardOffset = direction;
            endPoint = endCornerPoint;


        }
        
        private void applyAnimation()
        {

        }

        // public functions:
        public void endLevel(Player player)
        {
            // enter transition state
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
				bool check = false;
				foreach (GameObject j in gameObjectList)
				{
					if (i != j)
					{
						if (this.checkCollision(i, j))
						{
							check = true;
						}
					}
				}
				i.isColliding(check);
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
            
            gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(25, 300),Color.White));
            gameObjectList[1].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(75, 300), Color.White));
			gameObjectList[2].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(125, 300), Color.White));
			gameObjectList[3].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(175, 300), Color.White));
			gameObjectList[4].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(225, 300), Color.White));
			gameObjectList[5].load(Game1.objectPlaceHolderSave);
			
            for (int i = 0; i < objectNumber; i++)
			{
				gameObjectList.Add(new GameObject(GameJamGame.Game1.objectPlaceHolderSave, new Vector2(Game1.rnd.Next(10, 250), Game1.rnd.Next(10, 490)), Color.White));
				gameObjectList[i + 1].load(Game1.objectPlaceHolderSave);
			}
		}


		public void draw(SpriteBatch SB)
		{
            SB.Draw(this.currentBackGround, drawRect(this.boardOffset), Color.White);
			foreach (GameObject i in this.gameObjectList)
			{
				i.draw(SB, this.boardOffset);
			}
		}
        private Rectangle drawRect(Vector2 offset)
        {
            return new Rectangle(
                (int)(this.currentDrawRect.X + offset.X),
                (int)(this.currentDrawRect.Y + offset.Y),
                this.currentDrawRect.Width,
                this.currentDrawRect.Height);
        }
	}
}
