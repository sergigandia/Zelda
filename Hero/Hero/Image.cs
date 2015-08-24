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
    [Serializable]
    public class Image
    {
        public float Alpha;
        public string Text, FontName, Path;
        public Texture2D texture;
        public Vector2 Position;
        ContentManager content;
        public Rectangle SourceRect;
        public Rectangle rectangle;
        private float alpha=1.0f;
        public bool isActive { get; set; }
        public Image (string path,Vector2 position)
        {
        Path =path;
        Position = Vector2.Zero;
        SourceRect = Rectangle.Empty;
         }
        public Image(string path, Vector2 position,Rectangle rectangle)
        {
            Path = path;
            this.rectangle = rectangle;
            Position = Vector2.Zero;
            SourceRect = Rectangle.Empty;
        }
        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            if(Path!= String.Empty)
            {
                texture = content.Load<Texture2D>(Path);
            }
            Vector2 dimensions = Vector2.Zero;
            if(texture!=null)
            {
                dimensions.X+=texture.Width;
            dimensions.Y+=texture.Height;
            }
            if(SourceRect==Rectangle.Empty)
                SourceRect=new Rectangle(0,0,(int)dimensions.X,(int)dimensions.Y);

        }
        public void UnloadContent()
        {

        }
        public void update(GameTime time)
        {

        }
        public void draw(SpriteBatch sprite)
        {
            if (isActive == true)
            {
                if (rectangle == Rectangle.Empty)
                    sprite.Draw(texture, Position, Color.White);
                else
                {
                    sprite.Draw(texture, Position, rectangle, Color.White);
                }
            }
        }

    }
}
