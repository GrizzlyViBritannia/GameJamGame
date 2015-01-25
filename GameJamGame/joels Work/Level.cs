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
	public class Level
	{
		/*
		 * this class is going to be used to simply save the data in 
		 * memory. each Level will be created in code at initilisation
		*/
		public Texture2D backGround;
		public Rectangle drawRect;
		private List<GameObject> objectList;
        public Vector2 respawnPoint;

		public Level(Texture2D backGround, List<GameObject> gameObjectList, Vector2 respawnPoint)
		{
            this.respawnPoint = respawnPoint;
			this.backGround = backGround;
			this.drawRect = drawRect;
            objectList = new List<GameObject>();
            objectList = gameObjectList;
		}

        public List<GameObject> getObjectList()
        {
            return this.objectList;
        }

	}
}
