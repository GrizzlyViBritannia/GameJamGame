#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using GameJamGame.joels_Work;
#endregion

namespace GameJamGame
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
    /// 

    public struct levelImageSave
    {
        Texture2D BackGround;
    }

	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        Texture2D image; // piss off

        public static Texture2D backGroundPlaceHolderSave;
        public static Texture2D objectPlaceHolderSave;
        public static Texture2D playerTextureSave;


        public static Random rnd = new Random();




        Board gameBoard = new Board();
        List<Level> levelList;

		public Game1()
			: base()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here

            image = Content.Load<Texture2D>("Images/test"); // i hate you
            backGroundPlaceHolderSave = Content.Load<Texture2D>("Images/backgroundPlaceHolder");
            playerTextureSave = Content.Load<Texture2D>("Images/playerPlaceHolder.png");
            objectPlaceHolderSave = Content.Load<Texture2D>("Images/objectPlaceHolder.png");

            gameBoard.load(5);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			spriteBatch.Begin();

			spriteBatch.Draw(image, new Rectangle(0, 0, 800, 480), Color.White);
            gameBoard.draw(spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}




        /*
         * 
         * create level code
         * 
         */ 
        /*
        private List<Level> createLevels()
        {
            Level level1 = new Level();

            // add background texture
            level1.backGround =  
          
            
        }

        */
	}
}
