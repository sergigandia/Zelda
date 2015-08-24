using Hero.World.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Items
{
    public class Item
    {
        public int width , height;
        public Vector2 position;
        public Texture2D texture;
        public SpriteManager ActualAnimation;
        public List<SpriteManager> Animations;
        public bool active;
        public  Item(Vector2 position)
        {
            this.position = position;
        }
        public Rectangle rec()
        {
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }
        public virtual void LoadContent()
        {
            texture = ScreenManager.Instance.Content.Load<Texture2D>("items");
        }
        public virtual void Update(GameTime time)
        {
            ActualAnimation.update(time,position);
        }
        public virtual void Draw(SpriteBatch sprite)
        {
            ActualAnimation.draw(sprite,position);
        }

    }
}
