using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Entitys.Enemys
{
    class Octorock : Enemy 
    {
      public  enum Action
        {
            move = 0,
            attack=1
        }
        Random rand;
        OctorockBall ball;
        float timer,timer1,timera, timea;
        int speed;

        public Action action;
        public Octorock(Vector2 position,int i) :base(position)
        {
            kind = Enemy.Kind.A;
            base.health = 1;
        //    Console.WriteLine(base.health);
            int seed = unchecked(System.DateTime.Now.Millisecond);
             rand = new Random(seed*i);
             base.direction = Enemy.Direction.down;
             speed = 1;
             action = Action.move;
             base.width = 16;
             base.height = 16;
             ball = new OctorockBall(position, OctorockBall.Direction.down);
             created = false;
        }

        public override void LoadContent(WorldScreen screen)
        {
            base.LoadContent(screen);
          //  Animations = new List<SpriteManager>();
            var anim1l = new Rectangle(8, 8, 16, 16);
            var anim2l = new Rectangle(32, 8, 16, 16);
            var runleftRectangles = new List<Rectangle>();
            runleftRectangles.Add(anim1l);
            runleftRectangles.Add(anim2l);
            var runleft = new SpriteManager("runleft", base.tex, 200f, runleftRectangles);

            var anim1d = new Rectangle(56, 8, 16, 16);
            var anim2d = new Rectangle(80, 8, 16, 16);
            var rundownRectangles = new List<Rectangle>();
            rundownRectangles.Add(anim1d);
            rundownRectangles.Add(anim2d);
            var rundown = new SpriteManager("rundown", base.tex, 200f, rundownRectangles);

            var anim1r = new Rectangle(104, 8, 16, 16);
            var anim2r = new Rectangle(128, 8, 16, 16);
            var runrightRectangles = new List<Rectangle>();
            runrightRectangles.Add(anim1r);
            runrightRectangles.Add(anim2r);
            var runright = new SpriteManager("runright", base.tex, 200f, runrightRectangles);

            var anim1u = new Rectangle(152, 8, 16, 16);
            var anim2u = new Rectangle(176, 8, 16, 16);
            var runupRectangles = new List<Rectangle>();
            runupRectangles.Add(anim1u);
            runupRectangles.Add(anim2u);
            var runup = new SpriteManager("runup", base.tex, 200f, runupRectangles);

             Animations.Add(runleft);
             Animations.Add(rundown);
             Animations.Add(runup);
             Animations.Add(runright);
            ActualAnimation = getAnimation("runup");

            ball.loadContent(screen);
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
        public override Rectangle rectangle()
        {
            return base.rectangle();
        }
        public bool MoveCollision(Vector2 position, WorldScreen screen)
        {
            foreach (Tile t in screen.currentlay.Tiles)
            {
                if (t.type == Tile.Type.solid || t.type== Tile.Type.invisibol)
                    if (t.rectangle.Intersects(new Rectangle ((int)position.X ,(int)position.Y,16,16)))
                    {
                        return true;
                    }
            }
           foreach (Enemy t in screen.currentlay.enemys)
           {
               if(t.rectangle()!= rectangle())
               if (t.rectangle().Intersects(new Rectangle((int)position.X, (int)position.Y, 16, 16)))
                   return true;
           }
            return false;
        }
        public  void move(GameTime time, WorldScreen screen)
        {
            timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            if (timer > 2000)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        base.direction = Enemy.Direction.down;
                        break;
                    case 1:
                        base.direction = Enemy.Direction.right;
                        break;
                    case 2:
                        base.direction = Enemy.Direction.left;
                        break;
                    case 3:
                        base.direction = Enemy.Direction.up;
                        break;

                }
                timer = 0;
            }
            timer1 += (float)time.ElapsedGameTime.TotalMilliseconds;
            if (timer1 > 50)
            {
                timer1 = 0;
                if (direction == Enemy.Direction.down)
                {
                    if (!MoveCollision(new Vector2(position.X, position.Y + speed), screen))
                    {
                        base.position.Y += speed;
                        ActualAnimation = getAnimation("rundown");
                    }
                    else
                    {
                        base.direction = Enemy.Direction.right;
                    }
                }
                if (direction == Enemy.Direction.up)
                {
                    if (!MoveCollision(new Vector2(position.X, position.Y - speed), screen))
                    {
                        base.position.Y -= speed;
                        ActualAnimation = getAnimation("runup");
                    }
                    else
                    {
                        base.direction = Enemy.Direction.down;
                    }
                }
                if (direction == Enemy.Direction.right)
                {
                    if (!MoveCollision(new Vector2(position.X + speed, position.Y), screen))
                    {
                        base.position.X += speed;
                        ActualAnimation = getAnimation("runright");
                    }
                    else
                    {
                        base.direction = Enemy.Direction.left;
                    }
                }
                if (direction == Enemy.Direction.left)
                {
                    if (!MoveCollision(new Vector2(position.X - speed, position.Y), screen))
                    {
                        base.position.X -= speed;
                        ActualAnimation = getAnimation("runleft");
                    }
                    else
                    {
                        base.direction = Enemy.Direction.up;
                    }

                }
            }
        }
        public OctorockBall.Direction balldir(Direction dir )
        {
            switch (dir)
            {
                case Direction.down:
                    return OctorockBall.Direction.down;
                case Direction.up:
                    return OctorockBall.Direction.up;
                case Direction.left:
                    return OctorockBall.Direction.left;
                case Direction.right:
                    return OctorockBall.Direction.right;
            }
       return OctorockBall.Direction.down;
        }
        public void shoot(GameTime time, WorldScreen screen)
        {
            switch(direction )
            {
                case Direction.left:
                    ball.position = new Vector2(position.X - 8, position.Y+2);
                    break;
               case Direction.right:
                    ball.position = new Vector2(position.X +16, position.Y+2);
                    break;
                case Direction.up:
                    ball.position = new Vector2(position.X+2 , position.Y-10);
                    break;
                case Direction.down:
                    ball.position = new Vector2(position.X+2, position.Y + 16);
                    break;
        }

            ball.direction = balldir(direction);
        }
        public void attack(GameTime time , WorldScreen screen)
        {
            timera += (float)time.ElapsedGameTime.TotalMilliseconds;
            if(timera >175)
            {
                ball.alife = true;
                shoot(time, screen);
                timera = 0;
                action = Action.move;
            }
        }
        public override void update(GameTime time,WorldScreen screen)
        {
            base.update(time,screen);
            if (created)
            {
                ball.update(screen);
                if (health > 0)
                switch (action)
                {
                    case Action.move:
                        move(time, screen);
                        timea += (float)time.ElapsedGameTime.TotalMilliseconds;
                        if (timea > 1250 + rand.Next(0, 3000))
                        {
                            timea = 0;
                            action = Action.attack;
                        }
                        break;
                    case Action.attack:
                        attack(time, screen);
                        break;
                }
            }
        }
        public override void draw(SpriteBatch sprite,WorldScreen screen)
        {
                base.draw(sprite, screen);
                ball.draw(sprite, screen);
            
        }
    }
}
