using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace Hero
{
   public class GameScreen
    {
        public ContentManager content;
        [XmlIgnore]
        public Type Type;
       public GameScreen()
        {
            Type = this.GetType();
        }
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            ScreenManager.Instance.Content.Unload();
        }
        public virtual void Update(GameTime time)
        {
            InputManager.Instance.update(time);
        }
        public virtual void Draw(SpriteBatch sprite)
        {

        }
    }
}
