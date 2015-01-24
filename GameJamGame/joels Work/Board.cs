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
        public void logic(GameTime gameTime)
        {
            foreach (GameObject i in gameObjectList)
            {
                i.logic(gameTime);
            }



        }


        public void draw(SpriteBatch SB)
        {


        }

        

            
        


    }
}
