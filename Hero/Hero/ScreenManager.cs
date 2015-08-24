using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SwordSlayerREWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero
{

    public class ScreenManager
    {
        private static ScreenManager instance;
        public GraphicsDevice device { get;  set; }
        public Vector2 Dimensions { get; set; }
        public ContentManager Content { get; private set; }
        public GameScreen currentScreen,newScreen;
        public Font font;
        public SpriteBatch SpriteBatch;
        public bool isTransitioning { get; private set; }
        public Image ImageFadeOut;
        public Camera cam;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public void ChangeScreen(string screen)
        {
            newScreen = (GameScreen) Activator.CreateInstance(Type.GetType("Hero." + screen));
            isTransitioning = true;
            Console.WriteLine("Hero."+screen);
            ImageFadeOut.isActive = true;
            ImageFadeOut.Alpha = 0.0f;
        }

        void Transition(GameTime time)
        {
            if (isTransitioning)
            {
                ImageFadeOut.update(time);
               // if (ImageFadeOut.Alpha == 1.0f)
               // {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    currentScreen.LoadContent();
                isTransitioning = false;
                //}
            }
        }
        public ScreenManager()
        {
            font = new Font();
            ImageFadeOut = new Image("fadeout", Vector2.Zero);
            Dimensions = new Vector2(640,480);
            currentScreen = new TittleScreen();
        }
        public virtual void LoadContent(ContentManager Content, GraphicsDevice device)
        {
            this.device = device;
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }
        public virtual void UnloadContent()
        {
            currentScreen.UnloadContent();

        }
        public virtual void Update(GameTime time)
        {
            currentScreen.Update(time);
            Transition(time);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
      //      ImageFadeOut.draw(spriteBatch);
        }

        internal void UpdateCam(Camera cam)
        {
            this.cam = cam;
        }
    }
}
