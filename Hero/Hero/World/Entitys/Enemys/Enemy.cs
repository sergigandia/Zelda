using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Entitys.Enemys
{

    public class Enemy
    {
        public enum Kind {
            A=0,
            B=1,
            C=2,
            D=3,
            X=4,
        }
        public enum Direction
        {
            down = 0,
            up = 1,
            left = 2,
            right = 3
        }
       public Kind kind;
        public bool created;
        public Vector2 position;
        public Texture2D tex;
        public Texture2D hit;
        public int health;
        bool death;
        bool alife;
        public int width, height;
        public Direction direction;
        public SpriteManager ActualAnimation;
        public List<SpriteManager> Animations;
        float timer;
        public Enemy (Vector2 position)
        {
            this.position = position;
        }
        public virtual void LoadContent(WorldScreen screen)
        {
           hit = ScreenManager.Instance.Content.Load<Texture2D>("hit");
           tex=  Global.enemytex;
           Animations = new List<SpriteManager>();
           var anim1l = new Rectangle(0, 0, 15, 16);
           var anim2l = new Rectangle(16, 0, 15, 16);
           var anim3l = new Rectangle(31, 0, 9, 16);
           var anim4l = new Rectangle(40, 0, 9, 16);
           var runleftRectangles = new List<bigsprite>();
           runleftRectangles.Add(new bigsprite(anim1l,new Vector2(0,0)));
           runleftRectangles.Add(new bigsprite(anim2l, new Vector2(0, 0)));
           runleftRectangles.Add(new bigsprite(anim3l, new Vector2(6, 0)));
           runleftRectangles.Add(new bigsprite(anim4l, new Vector2(6, 0)));
           var death = new SpriteManager("death", hit, 100f, runleftRectangles);
           Animations.Add(death);
        }
        bool de=true;
        public virtual void update(GameTime time,WorldScreen screen)
        {
            if (!death)
            {
                if (created == false)
                {
                    timer += (float)time.ElapsedGameTime.TotalMilliseconds;
                    if (timer > 200)
                    {
                        timer = 0;
                        created = true;
                    }
                }
                else
                {
                    //    Console.WriteLine(health);
                    if (health <= 0)
                    {
                        if (de)
                        {
                            ActualAnimation = getAnimation("death");
                            de = false;
                        }
                        if (ActualAnimation.animFinish)
                        {
                            death = true;
                            screen.genItem(kind, new Vector2(rectangle().Center.X, rectangle().Center.Y),time);
                        }
                    }
                }
                ActualAnimation.update(time, position);
            }
        }
        public SpriteManager getAnimation(String name)
        {
            foreach (var sp in Animations)
            {
                if (sp.name == name)
                {
                    return sp;
                }
            }
            return null;
        }
        public virtual Rectangle rectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }
        public virtual void draw(SpriteBatch sprite, WorldScreen screen)
        {
            if (!death)
            {
                if (created == true)
                {
                    ActualAnimation.draw(sprite, position);
                }
                else
                {
                    sprite.Draw(tex, position, new Rectangle(1532, 32, 16, 16), Color.White);
                }
            }
        }


        internal void dmg(int p)
        {
            health -= p;
        }
    }
}
