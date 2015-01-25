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
        public Vector2 firstEndPoint;
        public Vector2 secondEndPoint;
        public bool respawnable;

        public Level(Texture2D backGround, List<GameObject> gameObjectList, Vector2 respawnPoint,Vector2 firstEndPoint, Vector2 secondEndPoint, bool respawnable)
		{
            this.respawnable = respawnable;
            this.secondEndPoint = secondEndPoint;
            this.firstEndPoint = firstEndPoint;
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
        public void addObject(GameObject gObject)
        {
            this.objectList.Add(gObject);
        }
        public void removeObject(GameObject gObject)
        {
            this.objectList.Remove(gObject);
        }
        public void changeRespawn(Vector2 input)
        {
            this.respawnPoint = input;
        }
	}
}
