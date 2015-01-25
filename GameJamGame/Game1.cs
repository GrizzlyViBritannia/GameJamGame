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


    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D image; // piss off

        public static Texture2D backGroundPlaceHolderSave;
        public static Texture2D objectPlaceHolderSave;
        //public static Texture2D playerTextureSave;

        public static Texture2D playerSpriteSheet;
        public static int currentLevel = -1;

        // level 1 tutorial level
        public static Texture2D level1BGSave;
        public static Texture2D level2BGSave;
        public static Texture2D level3BGSave;
        public static Texture2D level1BreakableBlockSave;

        public static Random rnd = new Random();




        static Board gameBoard = new Board();
        public static List<Level> levelList;

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
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
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
            //playerTextureSave = Content.Load<Texture2D>("Images/Level1/playerPlaceHolder2.png");
            objectPlaceHolderSave = Content.Load<Texture2D>("Images/objectPlaceHolder.png");

            // load spriteSheet
            playerSpriteSheet = Content.Load<Texture2D>("Images/Player/PlayerSpriteSheet1.bmp");

            // level 1 load
            level1BGSave = Content.Load<Texture2D>("Images/Level1/1_1BG.png");
            level2BGSave = Content.Load<Texture2D>("Images/Level1/1_2BG.png");
            level3BGSave = Content.Load<Texture2D>("Images/Level1/1_3.png");
            level1BreakableBlockSave = Content.Load<Texture2D>("Images/Level1/glass2.png");

            // create level data
            levelList = new List<Level>();
            levelList = createLevels();

            gameBoard.load(0);
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
			gameBoard.update(gameTime);


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

		public static void cycle()
		{
			gameBoard.cycleBlocks();
		}

		public static int getCycle()
		{
			return gameBoard.getCycleNumber();
		}

        /*
         * 
         * create level code
         * 
         */

        private List<Level> createLevels()
        {
            List<Level> returnList = new List<Level>();
            // lvl 1
            List<GameObject> level1GameObjectList = new List<GameObject>();
            level1GameObjectList = level1Objects();
            Level level1 = new Level(level1BGSave, level1GameObjectList, new Vector2(450,115));

            // lvl 2
            List<GameObject> level2GameObjectList = new List<GameObject>();
            level2GameObjectList = level2Objects();
            Level level2 = new Level(level2BGSave, level2GameObjectList, new Vector2(210, 175));

            // lvl 3
            List<GameObject> level3GameObjectList = new List<GameObject>();
            level3GameObjectList = level3Objects();
            Level level3 = new Level(level3BGSave, level3GameObjectList, new Vector2(390, 535));

            
            returnList.Add(level1);
            returnList.Add(level2);
            returnList.Add(level3);
            return returnList;

        }

        private List<GameObject> level1Objects()
        {
            List<GameObject> returnList = new List<GameObject>();

             // 60 - 60
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(510, 595), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(510, 535), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(570, 475), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(570, 535), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(630, 415), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(630, 475), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(690, 415), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(690, 355), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(750, 355), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(750, 295), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(810, 295), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(810, 235), Color.White));

            // add walls
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(290, 40, 390 - 290 , 660 - 40), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(370, 625, 920 - 370, 680 - 40), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(840, 205, 1050 - 840, 660 - 205), Color.White));

            return returnList;


        }
        private List<GameObject> level2Objects()
        {
            List<GameObject> returnList = new List<GameObject>();

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(270, 235), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(330, 235), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(390, 295), Color.White));

            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(450, 395), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(510, 415), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(570, 235), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(630, 535), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(680, 295), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(740, 535), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(800, 355), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(870, 535), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(930, 415), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(990, 545), Color.White));
            returnList.Add(new Shatter(level1BreakableBlockSave, new Vector2(990, 605), Color.White));

            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(150, 0, 240 - 150, 140 - 0), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(80, 80, 180 - 80, 230 - 80), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(160, 205, 240 - 160, 800 - 205), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(1080, 0, 1160 - 1080, 505 - 0), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(1080, 565, 1200 - 1080, 715 - 565), Color.White));




            return returnList;


        }
        private List<GameObject> level3Objects()
        {
            List<GameObject> returnList = new List<GameObject>();

            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(260, 50, 480 - 260, 500 - 50), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(275, 400, 360 - 275, 600 - 400), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(450, 625, 885 - 450, 665 - 625), Color.White));
            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(840, 130, 900 - 840, 870 - 130), Color.White));

            returnList.Add(new invisibleBlock(objectPlaceHolderSave, new Rectangle(320, 565, 480 - 320, 630 - 565), Color.White));


            return returnList;


        }


    }
}
