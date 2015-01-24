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
    class Level 
    {
        /*
         * this class is going to be used to simply save the data in 
         * memory. each Level will be created in code at initilisation
        */
        Texture2D backGround;
        Rectangle drawRect;
        List<GameObject> objectList;



        public Level(Texture2D backGround, Rectangle drawRect, List<GameObject> gameObject)
        {
            this.backGround = backGround;
            this.drawRect = drawRect;
        }
               

    }
}
