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
