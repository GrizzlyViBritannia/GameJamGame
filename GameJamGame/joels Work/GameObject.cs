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
    class GameObject
    {
        // logic variables
        protected Vector2 centerPosition;
        protected Rectangle collisonRect;
        protected bool movable;

        // draw variable
        protected Rectangle drawRect;
        protected Color colour;
        protected Texture2D sprite;

        // private functions:
        


        // public functions:
        public void moveObject(Vector2 input)
        {
            this.centerPosition += input;
        }


        // get-set functions:
        public bool isMovable()
        {
            return this.movable;
        }


        /*
         * Chris, produce a function to go in the Board class (not yet created).
         * the functions will take two objects, check if they are colliding, and 
         * fix the collision via the "moveObject(Vector2)" function.
         * this function takes a Vector2 variable and will move the object by 
         * said vector
         */

    }
}
