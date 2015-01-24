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
        Player player;

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
        }

        // public logic-draw functions
        public void update(GameTime gameTime)
        {
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
            gameObjectList.Add(new Player(Game1.playerTextureSave, new Rectangle(0,0,50,50), Color.White)); // player will always be index 0
            gameObjectList[0].load(Game1.playerTextureSave);
            for (int i = 0; i < objectNumber; i++)
            {
                gameObjectList.Add(new GameObject(GameJamGame.Game1.objectPlaceHolderSave, new Rectangle(Game1.rnd.Next(10, 250), Game1.rnd.Next(10, 490), 25, 25), Color.White));
                gameObjectList[i+1].load(Game1.objectPlaceHolderSave);
            }
        }


        public void draw(SpriteBatch SB)
        {
            SB.Draw(this.currentBackGround, this.currentDrawRect, Color.White);
            foreach(GameObject i in this.gameObjectList)
            {
                i.draw(SB);
            }

        }


    }
}
