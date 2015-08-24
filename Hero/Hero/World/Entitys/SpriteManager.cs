using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hero.World.Entitys
{
    public struct bigsprite
    {
        public bigsprite(Rectangle rectangle,Vector2 position)
        {
            this.position = position;
            this.rectangle = rectangle;
        }
      public Vector2 position;
      public  Rectangle rectangle;
    }
    public class SpriteManager
    {
        private float transitionTime;
        public int index { get; set; }
        public float Time { get; set; }
        public Texture2D texture;
        public List<Rectangle> frames;
        public Vector2 position;
        public List<Vector2> add;
        public string name { get; private set; }
        public bool animFinish;
        public int old;
        public int more;
        public SpriteManager(string name,Texture2D texture,float time, List<Rectangle> frames)
        {
            this.name = name;
            this.texture = texture;
            this.frames = frames;
            transitionTime = time;
        }
        public SpriteManager(string name, Texture2D texture, float time, List<bigsprite> frames)
        {
            this.name = name;
            this.texture = texture;
            List<Rectangle> rectangles=new List<Rectangle>();
            add = new List<Vector2>();
            foreach (bigsprite f in frames)
            {
                    rectangles.Add(f.rectangle);
                   add.Add(f.position);
            }
         //   this.add=
            this.frames = rectangles;
            transitionTime = time;
        }
        public void update(GameTime time,Vector2 position)
        {
            this.position = position;
            this.Time += (float) time.ElapsedGameTime.TotalMilliseconds;
            int old =frames[index].Width;
            if (Time > transitionTime)
            {
                index++;
                this.Time = 0;
            }
            if (index > frames.Count - 1)
            {
                index = 0;
                animFinish = true;
            }

        }
        public void draw(SpriteBatch sprite, Vector2 position)
        {
            this.position = position;
            if(add!=null)
            sprite.Draw(texture,position+add[index],frames[index],Color.White);
            else
                sprite.Draw(texture, position , frames[index], Color.White);
        }
    }
}
