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
        protected bool collidable;

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

        // main logic-draw functions

        public void logic(GameTime gameTime)
        {

        }
        public void draw (SpriteBatch SB)
        {

        }


        // get-set functions:
        public bool isMovable()
        {
            return this.movable;
        }
        public bool isCollidable()
        {
            return this.collidable;
        }


    }
}
