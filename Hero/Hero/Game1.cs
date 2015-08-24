using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SwordSlayerREWork;
using System;

namespace Hero
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Camera cam;
        public Game1()
        {
     //      this.Window.IsBorderless = true;
        //    this.screen
            graphics = new GraphicsDeviceManager(this);
        //    graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            // 256x240
            this.graphics.PreferredBackBufferWidth = 256*(int)Global.zoom;
            this.graphics.PreferredBackBufferHeight = 240*(int)Global.zoom;
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
           Console.WriteLine( GraphicsDevice.Viewport.X);
           cam = new Camera(new Viewport(0, 0, 256 * (int)Global.zoom, 174 * (int)Global.zoom));
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
            ScreenManager.Instance.device = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            Global.fontTex = Content.Load<Texture2D>("font");
            Global.enemytex = Content.Load<Texture2D>("overworlde");
            ScreenManager.Instance.LoadContent(Content,GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
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
            cam.Update(gameTime);
            ScreenManager.Instance.UpdateCam(cam);
            ScreenManager.Instance.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null,cam.Transform);
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
