using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Entitys.Enemys
{
   public class OctorockBall
    {
       public enum Direction
        {
            right = 0,
            left=1,
            up=2,
            down=3
        }
        public Vector2 position;
        public Direction direction;
        Texture2D texture;
        float speed;
        public bool alife;
        public OctorockBall(Vector2 position, Direction direction)
        {
            this.position=position;
            this.direction = direction;
            speed = 2;
            alife = false;
        }
        public Rectangle rec()
        {
            return new Rectangle((int)position.X,(int)position.Y,8,10);
        }
        public void loadContent(WorldScreen screen)
        {
            texture=screen.player.texture;
        }
        public bool Collision(WorldScreen screen)
        {
     /*       foreach(Tile t in screen.currentlay.Tiles)
                {
                    if (t.type == Tile.Type.solid)
                    {
                        if (rec().Intersects(t.rectangle))
                        {

                            alife = false;
                            return true;

                        }
                    }
            
            }*/
            if(rec().Intersects(screen.player.rec()))
            {
                alife = false;
                screen.player.health -= 1;
                return true;
            }
           if (!ScreenManager.Instance.cam.recCamera().Contains(new Point((int)position.X, (int)position.Y)))
            {
                alife = false;
                return true;
            }
                            return false;
        }
        public void update(WorldScreen screen)
        {
            if (alife)
            {
                switch (direction)
                {
                    case Direction.right:
                    if(!Collision(screen))
                        position.X+=speed;
                        break;
                    case Direction.left:
                        if(!Collision(screen))
                                  position.X-=speed;
                                  break;
                    case Direction.down:
                                  if (!Collision(screen))
                                  position.Y+=speed;
                        break;
                    case Direction.up:
                        if (!Collision(screen))
                                  position.Y-=speed;
                        break;
                }
            }

        }
        public void draw(SpriteBatch sprite,WorldScreen screen)
        {
            if(alife)
            {
                sprite.Draw(texture, position, new Rectangle(394, 228, 8, 10), Color.White);
                if(Global.Collisions)
                {

                    sprite.Draw(screen.currentlay.collisiontex, position, new Rectangle(105, 0, 8, 10), Color.Bisque * 0.5f);
                }
            }
            }

    }
}
  