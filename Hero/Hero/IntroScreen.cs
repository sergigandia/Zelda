
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
namespace Hero
{
    public class IntroScreen : GameScreen
    {
        List<Texture2D> TittleTex = new List<Texture2D>();
        public Image Image;
        public Vector2 position=new Vector2(
            150,150);
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void LoadContent()
        {
            base.LoadContent();
            /*    TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[1]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[2]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[3]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[4]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[5]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[6]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[7]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[8]));
                TittleTex.Add(ScreenManager.Instance.Content.Load<Texture2D>(path[9]));*/
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            ScreenManager.Instance.font.DrawString(spriteBatch, "intro", new Vector2(position.X, position.Y), 20);
        }
    }
}
