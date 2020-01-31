using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameTest2.Globals;
using GameTest2.Entities;
using GameTest2.Managers;
using GameTest2.Models;
using System.Collections.Generic;

namespace GameTest2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Terrain> TerrainList;
        Dictionary<string, Animation> AnimationList;

        Player Player;

        Background Background;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferHeight = 1000;
            //graphics.PreferredBackBufferWidth = 500;
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

            AnimationList = new Dictionary<string, Animation>()
            {
                {"IdleRight", new Animation(Content.Load<Texture2D>("IdleRight"),4,0.4f,false) },
                {"IdleLeft", new Animation(Content.Load<Texture2D>("IdleLeft"),4,0.4f,false) },
                {"RunLeft", new Animation(Content.Load<Texture2D>("RunLeft"),6,0.1f,false) },
                {"RunRight", new Animation(Content.Load<Texture2D>("RunRight"),6,0.1f,false) },
                {"Attack01Right", new Animation(Content.Load<Texture2D>("Attack01Right"),5,0.1f,true) },
                {"Attack01Left", new Animation(Content.Load<Texture2D>("Attack01Left"),5,0.1f,true) },
                {"Attack02Right", new Animation(Content.Load<Texture2D>("Attack02Right"),4,0.1f,true) },
                {"Attack02Left", new Animation(Content.Load<Texture2D>("Attack02Left"),4,0.1f,true) },
                {"Attack03Right", new Animation(Content.Load<Texture2D>("Attack03Right"),6,0.1f,true) },
                {"Attack03Left", new Animation(Content.Load<Texture2D>("Attack03Left"),6,0.1f,true) },
            };

            Player = new Player(AnimationList, new Vector2(100, 100))
            {
                Input = new Input
                {
                    Attack01 = Keys.A,
                    Attack02 = Keys.S,
                    Attack03 = Keys.D,
                    Left = Keys.Left,
                    Right = Keys.Right,
                    Run = Keys.LeftShift,
                   
                },
                Speed = 2f,
                FixedPositionX = 100f,
                
            };

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            Player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            Player.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
