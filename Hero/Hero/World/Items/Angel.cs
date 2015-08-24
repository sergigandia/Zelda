using Hero.World.Entitys.Enemys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Items
{
    class Angel : Item
    {
        Enemy.Direction direction;
        float speed = 1f;
                   public Angel(Vector2 position) : base(position)
        {
               width=7;
              height=16;
            LoadContent();
            direction = Enemy.Direction.right;
         }
           public override void LoadContent()
        {
            base.LoadContent();
             List<Rectangle> rec = new List<Rectangle>();
            rec.Add(new Rectangle(40,0,7,16));
            ActualAnimation=new Entitys.SpriteManager("Angel",texture,100f,rec);
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            if (checkCollision())
            {
                if (direction == Enemy.Direction.right)
                {
                    position.X += speed;
                    position.Y += speed;

                }
                if (direction == Enemy.Direction.left)
                {
                    position.X -= speed;
                    position.Y -= speed;

                }
                if (direction == Enemy.Direction.up)
                {
                    position.X -= speed;
                    position.Y += speed;
                }
                if (direction == Enemy.Direction.down)
                {
                    position.X += speed;
                    position.Y -= speed;
                }
            }
            else
            {
                changeDirection();
            }
           base.Update(time);
        }

        private void changeDirection()
        {
            if(direction == Enemy.Direction.down)
            {
                direction = Enemy.Direction.right;
            }
            else if(direction == Enemy.Direction.right)
            {
                direction = Enemy.Direction.up;
            }
            else if(direction==Enemy.Direction.up)
            {
                direction = Enemy.Direction.left;
            }
            else if(direction== Enemy.Direction.left)
            {
                direction=Enemy.Direction.down;
            }
            Console.WriteLine(direction);
        }
        public Vector2 getPos()
        {
            var pos = position;
            if (direction == Enemy.Direction.right)
            {
                pos.X += speed;
                pos.Y += speed;

            }
            else if (direction == Enemy.Direction.left)
            {
                pos.X -= speed;
                pos.Y -= speed;

            }
            else if (direction == Enemy.Direction.up)
            {
                pos.X -= speed;
                pos.Y += speed;
            }
            else if (direction == Enemy.Direction.down)
            {
                pos.X += speed;
                pos.Y -= speed;
            }
            return pos;

        }
        public  bool checkCollision()
        {
            if(new Rectangle((int)getPos().X,(int)getPos().Y,width,height).Intersects(ScreenManager.Instance.cam.recCamera()))
            {
                
                return true;
            }
            return false;
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite)
        {
            base.Draw(sprite);
        }
    }
}
