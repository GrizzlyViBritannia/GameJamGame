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
        // const
        const String transitionState = "transition";
        const String updateState = "update";
        const int forward = 1;
        const int backwards = -1;



		Texture2D currentBackGround;
		//Rectangle currentDrawRect;
		List<GameObject> gameObjectList;
        Player playerPointer;

        String state = updateState;

        Board transitionBoard = null;

        // animation stuff:
        Vector2 boardOffset = Vector2.Zero;
        Vector2 directionOffset = Vector2.Zero;
        float speed = 1.0f;
        Vector2 endPoint = Vector2.Zero;

        int currectDirection = 0;
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

            //if rectangle1 and rectangle2 are colliding
            if (o1Rect.Intersects(o2Rect))
            {
                //if rectangle1 is movable move it away from rectangle2
                if (object1.isMovable())
                {

                    Vector2 currentSpeed = object1.getSpeed();
                    Rectangle oldPos = object1.drawRect(-currentSpeed);

                    float[] intersect = new float[] { -999, -999, -999, -999 };
                    //Top


                    if (o1Rect.Bottom > o2Rect.Top && o1Rect.Bottom < o2Rect.Bottom)
                    {
                        intersect[0] = o2Rect.Top - o1Rect.Bottom;
                    }
                    //Right
                    if (o1Rect.Left < o2Rect.Right && o1Rect.Left > o2Rect.Left)
                    {
                        intersect[1] = o2Rect.Right - o1Rect.Left;
                    }
                    //Bottom
                    if (o1Rect.Top < o2Rect.Bottom && o1Rect.Top > o2Rect.Top)
                    {
                        intersect[2] = o2Rect.Bottom - o1Rect.Top;
                    }
                    //Left
                    if (o1Rect.Right > o2Rect.Left && o1Rect.Right < o2Rect.Right)
                    {
                        intersect[3] = o2Rect.Left - o1Rect.Right;
                    }

                    int index = 0, count = 0;

                    foreach (float intersection in intersect)
                    {
                        if ((Math.Abs(intersection) < Math.Abs(intersect[index])) && Math.Abs(intersection) != 0)
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
                    object1.isColliding(true);
                    
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

		//private bool checkAdjacent(GameObject object1, GameObject object2)
		//{
		//	Rectangle o1Rect = object1.getCollisionRect();
		//	Rectangle o2Rect = object2.getCollisionRect();
        //
		//	if 
		//		(((o1Rect.Top == o2Rect.Bottom || o1Rect.Bottom == o2Rect.Top) && ((o1Rect.Left < o2Rect.Right && o1Rect.Left > o2Rect.Left) || (o1Rect.Right > o2Rect.Left && o1Rect.Right < o2Rect.Right)))
		//		||
		//		((o1Rect.Left == o2Rect.Right || o1Rect.Right == o2Rect.Left) && ((o1Rect.Bottom > o2Rect.Top && o1Rect.Bottom < o2Rect.Bottom) || (o1Rect.Top < o2Rect.Bottom && o1Rect.Top > o2Rect.Top))))
		//	{
		//		if (object1.GetType() == typeof(Player) || object2.GetType() == typeof(Player))
		//		return true;
		//	}
        //
		//	return false;
		//}

        public void declareTransition(Vector2 endCornerPoint, Vector2 startPoint)
        {
            this.boardOffset = startPoint;
            directionOffset = (endCornerPoint - new Vector2(drawRect(this.boardOffset).X, drawRect(this.boardOffset).Y)) / 100;
            endPoint = endCornerPoint;
        }
        
        private void applyTransmitionAnimation()
        {
            boardOffset += directionOffset;
        }

        // public functions:
        public void endLevel(int direction)
        {
            
            state = transitionState;
            declareTransition(new Vector2(-1280*direction, 0), this.boardOffset);
            getPlayer().setPosition(getPlayer().getCenterPosition() + new Vector2(-1280 * direction, 0));
            StartTransition(direction);
            

        }

        public void buildBoard(Level level, Player player)
        {
            this.boardOffset = Vector2.Zero;
            this.currentBackGround = level.backGround;
            this.state = transitionState;
            if (this.gameObjectList != null)
                this.gameObjectList.Clear();
            else
                this.gameObjectList = new List<GameObject>();
            this.gameObjectList.Add(player);
            this.gameObjectList.AddRange(level.getObjectList());
        }
        void StartTransition(int direction)
        {
            transitionBoard = new Board();
            transitionBoard.buildBoard(Game1.levelList[Game1.currentLevel + direction], getPlayer());
            transitionBoard.declareTransition(Vector2.Zero, new Vector2(1280*direction, 0));
        }

        void endTransition(int direction)
        {
            transitionBoard = null;
            //this.gameObjectList[0].moveObject(new Vector2(-800, 0));
            Game1.currentLevel += direction;
            this.buildBoard(Game1.levelList[Game1.currentLevel], (Player)gameObjectList[0]);
            //Game1.levelList.RemoveAt(0);
            this.state = updateState;
        }

		// public logic-draw functions
		public void update(GameTime gameTime)
		{
            
            if (state == updateState)
            {
                

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    currectDirection = forward;
                    endLevel(forward);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    currectDirection = backwards;
                    endLevel(backwards);
                }

                foreach (GameObject i in gameObjectList)
                {
                    i.update(gameTime);
                    i.isColliding(false);
                }
                foreach (GameObject i in gameObjectList)
                {
					foreach (GameObject j in gameObjectList)
					{
						if (i != j)
						{
                            if (this.checkCollision(i, j))
                            {
                                i.isColliding(true);
                                j.isColliding(true);
                            }
						}
					}
				}
            }
            else if (state == transitionState)
            {
                transitionBoard.applyTransmitionAnimation();
                this.applyTransmitionAnimation();
                if (Vector2.Distance(boardOffset, endPoint) < directionOffset.Length() / 1.5f)
                {
                    if (currectDirection != 0)
                        endTransition(currectDirection);
                    else
                    {
                        // something is fucking broken
                    }
                }
            }
			List<GameObject> bufferList = new List<GameObject>();
			foreach (GameObject i in gameObjectList)
			{
				if (!i.delete())
				{
					bufferList.Add(i);
				}
			}
			this.gameObjectList = bufferList;
			

		}

		public void load(int objectNumber)
		{
			this.currentBackGround = Game1.backGroundPlaceHolderSave;
			gameObjectList = new List<GameObject>();
			gameObjectList.Add(new Player(Game1.playerTextureSave, new Vector2(0, 0), Color.White)); // player will always be index 0
			gameObjectList[0].load(Game1.playerTextureSave);
            playerPointer = (Player)gameObjectList[0];
            
            gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(25, 300),Color.White));
            gameObjectList[1].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new Shatter(Game1.objectPlaceHolderSave, new Vector2(75, 300), Color.White));
			gameObjectList[2].load(Game1.objectPlaceHolderSave);
			gameObjectList.Add(new GameObject(Game1.objectPlaceHolderSave, new Vector2(125, 300), Color.White));
			gameObjectList[3].load(Game1.objectPlaceHolderSave);
			
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

            if (transitionBoard != null)
                transitionBoard.draw(SB);
		}
        private Rectangle drawRect(Vector2 offset)
        {
            return new Rectangle(
                (int)(offset.X),
                (int)(offset.Y),
                this.currentBackGround.Width,
                this.currentBackGround.Height);
        }
		

        // get-set
        public Player getPlayer()
        {
            return (Player)this.gameObjectList[0];
        }
        public void startUpdate()
        {
            this.state = updateState;
        }
	}
}
