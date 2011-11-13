using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace AN
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        Camera camera;
        KeyboardState current;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Sprite mSprite;
        //Sprite mSpriteTwo;
        //Nerd nerd;
        Mousedraggable nerd;


        Sprite mBackgroundOne;
        Sprite mBackgroundTwo;
        Sprite mBackgroundThree;
        Sprite mBackgroundFour;
        Sprite mBackgroundFive;


        public Game1()
        {
            camera = new Camera();
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 850;
            graphics.PreferredBackBufferHeight = 650;
            Content.RootDirectory = "Content";
            /*
             * ONLY UNCOMMENT THESE IF YOU HAVE FBBDEPROFILER DOWNLOADED, AND IN THE REFERENCES!
             * -noemj
             */
            graphics.GraphicsProfile = GraphicsProfile.Reach;
            //fbDeprofiler.DeProfiler.Run();

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
            this.IsMouseVisible = true;
            //nerd = new Nerd();
            nerd = new Mousedraggable();
            //mSprite = new Sprite();
            //mSpriteTwo = new Sprite();

            mBackgroundOne = new Sprite();
            mBackgroundOne.Scale = 0.85f;

            mBackgroundTwo = new Sprite();
            mBackgroundTwo.Scale = 2.0f;

            mBackgroundThree = new Sprite();
            mBackgroundThree.Scale = 2.0f;

            mBackgroundFour = new Sprite();
            mBackgroundFour.Scale = 2.0f;

            mBackgroundFive = new Sprite();
            mBackgroundFive.Scale = 2.0f;

            base.Initialize();
        }




        // Set the coordinates to draw the sprite at.
        Vector2 spritePosition = Vector2.Zero;

        // Store some information about the sprite's motion.
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 

        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            nerd.LoadContent(this.Content);
            //nerd.Position.X = 300;
            //nerd.Position.Y = 300;

            // TODO: use this.Content to load your game content here
            //mSprite.LoadContent(this.Content, "birdy");
            //mSprite.Position = new Vector2(125, 245);

            //mSpriteTwo.LoadContent(this.Content, "birdy");
            //mSpriteTwo.Position.X = 300;
            //mSpriteTwo.Position.Y = 300;

            mBackgroundOne.LoadContent(this.Content, "Background");
            mBackgroundOne.Position = new Vector2(0, 0);


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

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            current = Keyboard.GetState();
            Camera.Update(current);


            // TODO: Add your update logic here
            nerd.Update(gameTime);

            Vector2 aDirection = new Vector2(-1, 0);
            Vector2 aSpeed = new Vector2(160, 0);


            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);



            spriteBatch.Begin();
            /* FOR THE CAMERA..  Doesnt work yet.
             * -noemj
            spriteBatch.Begin(SpriteSortMode.Immediate,

               BlendState.AlphaBlend,
               null,
               null,
               null,
               null,
               Camera.TransformMatrix());

            spriteBatch.End();
            spriteBatch.Begin();
             * */
            mBackgroundOne.Draw(spriteBatch);
            mBackgroundTwo.Draw(this.spriteBatch);

            nerd.Draw(this.spriteBatch);
            //mSprite.Draw(this.spriteBatch);
            //mSpriteTwo.Draw(this.spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}