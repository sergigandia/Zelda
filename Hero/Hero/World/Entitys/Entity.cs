using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Entitys
{
    class Entity
    {
        public enum Direction
        {
            down = 0,
            up = 1,
            left = 2,
            right = 3
        }
        public bool created;
        public Vector2 position;
        public Texture2D tex;
        public int width, height;
        public Direction direction;
        public SpriteManager ActualAnimation;
        public List<SpriteManager> Animations;
        public Entity(Vector2 position)
        {
            this.position = position;
        }
        public virtual void LoadContent(WorldScreen screen)
        {
        }
        public virtual Rectangle rectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }
        public virtual void update(GameTime time, WorldScreen screen)
        {
        }
        public virtual void draw(SpriteBatch sprite, WorldScreen screen)
        {
                ActualAnimation.draw(sprite, position);
                sprite.Draw(tex, position, new Rectangle(1532, 32, 16, 16), Color.White);
            
        }

    }
}
