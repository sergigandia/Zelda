using System;
using System.Collections.Generic;
using Hero.World;
using Hero.World.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Hero.World.Entitys.Enemys;

namespace Hero
{
   public class Player
    {
      public enum Weapons1
       {
          Sword=0
       }
        private readonly float speed;
        private Action action;
        public SpriteManager ActualAnimation;
        public List<SpriteManager> Animations;
        private Direction direction;
        public int health;
        public Rectangle limits = new Rectangle(0, 64, 241, 224);
        public Vector2 position;
        public Weapons1 weaponA;
        public Weapons1 weaponB;
        public Texture2D texture,collisiontex;
        private bool attack;
        public int totalhealth;
        public Player(WorldScreen screen)
        {
            totalhealth = 6;
            health = 6;
            speed = 1;
            action = Action.still;
            position = new Vector2(+512+75,434+100 );
            direction = Direction.down;
        }
       public Rectangle rec()
        {
            return new Rectangle((int)position.X,(int)position.Y, 15, 16);
        }
       public Rectangle recSword()
       {
           if (ActualAnimation.name == "downsword" || ActualAnimation.name == "upsword" || ActualAnimation.name == "leftsword" || ActualAnimation.name == "rightsword")
           {
               if(ActualAnimation.name == "downsword")
               {
                  return new Rectangle((int)position.X+6, (int)position.Y+16,3,11);
               }
               else if (ActualAnimation.name == "upsword")
               {
                   return new Rectangle((int)position.X + 6, (int)position.Y-11 , 3, 11);
               }
               else if (ActualAnimation.name == "rightsword")
               {
                   return new Rectangle((int)position.X +15, (int)position.Y +6, 3, 11);
               }
               else if (ActualAnimation.name == "leftsword")
               {
                   return new Rectangle((int)position.X -11, (int)position.Y + 6, 3, 11);
               }
               return new Rectangle(0, 0, 0, 0);
           }
           else
           {
               return new Rectangle(0,0,0,0);
           }
       }
        public void LoadContent()
        {
            texture = ScreenManager.Instance.Content.Load<Texture2D>("player");
            collisiontex = ScreenManager.Instance.Content.Load<Texture2D>("tileset/kind");
            var anim1d = new Rectangle(0, 0, 15, 16);
            var anim2d = new Rectangle(0, 30, 15, 16);
            var rundownRectangles = new List<Rectangle>();
            rundownRectangles.Add(anim1d);
            rundownRectangles.Add(anim2d);
            var rundown = new SpriteManager("rundown", texture, 200f, rundownRectangles);

            var anim1l = new Rectangle(30, 0, 15, 16);
            var anim2l = new Rectangle(30, 30, 15, 16);
            var runleftRectangles = new List<Rectangle>();
            runleftRectangles.Add(anim1l);
            runleftRectangles.Add(anim2l);
            var runleft = new SpriteManager("runleft", texture, 200f, runleftRectangles);

            var anim1u = new Rectangle(60, 0, 15, 16);
            var anim2u = new Rectangle(60, 30, 15, 16);
            var runupRectangles = new List<Rectangle>();
            runupRectangles.Add(anim1u);
            runupRectangles.Add(anim2u);
            var runup = new SpriteManager("runup", texture, 200f, runupRectangles);


            var anim1r = new Rectangle(90, 0, 15, 16);
            var anim2r = new Rectangle(90, 30, 15, 16);
            var runriRectangles = new List<Rectangle>();
            runriRectangles.Add(anim1r);
            runriRectangles.Add(anim2r);
            var runright = new SpriteManager("runright", texture, 200f, runriRectangles);

            var dRectangles = new List<Rectangle>();
            dRectangles.Add(new Rectangle(0, 0, 15, 16));
            var stilldown = new SpriteManager("stilldown", texture, 200f, dRectangles);
            var lRectangles = new List<Rectangle>();
            lRectangles.Add(new Rectangle(30, 0, 15, 16));
            var stillleft = new SpriteManager("stillleft", texture, 200f, lRectangles);

            var uRectangles = new List<Rectangle>();
            uRectangles.Add(new Rectangle(60, 0, 15, 16));
            var stillup = new SpriteManager("stillup", texture, 200f, uRectangles);

            var rRectangles = new List<Rectangle>();
            rRectangles.Add(new Rectangle(90, 0, 15, 16));
            var stillright = new SpriteManager("stillright", texture, 200f, rRectangles);
            Animations = new List<SpriteManager>();

            var sworddownrec = new List<Rectangle>();
            sworddownrec.Add(new Rectangle(0, 60, 15, 16));
            sworddownrec.Add(new Rectangle(0, 84, 16, 27));
            var downsword = new SpriteManager("downsword", texture, 150f, sworddownrec);

            var swordleftnrec = new List<bigsprite>();
            swordleftnrec.Add(new bigsprite(new Rectangle(30,60,16,15),new Vector2(0,0)));
            swordleftnrec.Add(new bigsprite(new Rectangle(24, 90, 27, 15),new Vector2(-11,0)));
           var leftsword = new SpriteManager("leftsword",texture,150f,swordleftnrec);

            var sworduprec = new List<bigsprite>();
            sworduprec.Add(new bigsprite(new Rectangle(60,60,16,16),new Vector2(0,0)));
            sworduprec.Add(new bigsprite(new Rectangle(60, 84, 16, 28),new Vector2(0,-11)));
            var upsword = new SpriteManager("upsword", texture, 150f, sworduprec);

            var swordrightrec = new List<Rectangle>();
            swordrightrec.Add(new Rectangle(90, 60, 15, 16));
            swordrightrec.Add(new Rectangle(84,90,27,15));
            var rightsword = new SpriteManager("rightsword", texture, 150f, swordrightrec);
            Animations.Add(rightsword);
            Animations.Add(upsword);
            Animations.Add(downsword);
          Animations.Add(leftsword);

            Animations.Add(rundown);
            Animations.Add(runleft);
            Animations.Add(runup);
            Animations.Add(runright);
            Animations.Add(stilldown);
            Animations.Add(stillleft);
            Animations.Add(stillup);
            Animations.Add(stillright);
            ActualAnimation = getAnimation("stilldown");
        }
        public void Keyboard()
        {
          if(  InputManager.Instance.keyPressed(Keys.F5))
            {
                if (Global.Collisions == false) Global.Collisions = true;
                else Global.Collisions = false;
            }
        }
       public void Aaction()
        {   
           action = Action.attack;
           if (direction == Direction.right)
           {
               ActualAnimation = getAnimation("rightsword");
           }
           if (direction == Direction.up)
           {
               ActualAnimation = getAnimation("upsword");
           }
           if (direction == Direction.left)
           {
               ActualAnimation = getAnimation("leftsword");
           }
           if (direction == Direction.down)
           {
               ActualAnimation = getAnimation("downsword");
           }
         
        }
       public void checkCollision(WorldScreen screen)
       {
           foreach(Enemy e in screen.currentlay.enemys )
           {
               if(recSword().Intersects(e.rectangle()))
               {
                   e.dmg(1);
               }
           }
       }
        public void update(GameTime time, WorldScreen world)
        {
            checkCollision(world);

            if (action != Action.attack)
            {
                action = Action.still;
                if (InputManager.Instance.keyDown(Keys.Down))
                    MoveDown(world);
                else if (InputManager.Instance.keyDown(Keys.Up))
                    MoveUp(world);
                else if (InputManager.Instance.keyDown(Keys.Left))
                    MoveLeft(world);
                else if (InputManager.Instance.keyDown(Keys.Right))
                    MoveRight(world);
                if (InputManager.Instance.keyPressed(Keys.X))
                Aaction();
            }
            else
            {
            action_atack();
            }

            CameraCheck(world);
            if (action == Action.still)
            {
                getCurrentAnim();
            }
            ActualAnimation.update(time, position);
            Keyboard();
        }

        private void action_atack()
        {

            if(ActualAnimation.animFinish==true)
            {
                action = Action.still;
                ActualAnimation.animFinish = false;
            }


        }
        public void CameraCheck(WorldScreen world)
        {
            if (!ScreenManager.Instance.cam.isTransitioning)
            {
                try
                {
                    if (position.X > ScreenManager.Instance.cam.recCamera().X + ScreenManager.Instance.cam.recCamera().Width)
                    {

                        world.ActualVec.Y++;
                        world.currentlay = world.OverWorld[(int)world.ActualVec.X, (int)world.ActualVec.Y];
                        ScreenManager.Instance.cam.isTransitioning = true;
                        ScreenManager.Instance.cam.wait = true;
                    }
                    if (position.X < ScreenManager.Instance.cam.recCamera().X)
                    {
                        world.ActualVec.Y--;
                        world.currentlay = world.OverWorld[(int)world.ActualVec.X, (int)world.ActualVec.Y];
                        ScreenManager.Instance.cam.isTransitioning = true;
                        ScreenManager.Instance.cam.wait = true;
                    }
                    if (position.Y > ScreenManager.Instance.cam.recCamera().Y + ScreenManager.Instance.cam.recCamera().Height)
                    {
                        world.ActualVec.X++;
                        world.currentlay = world.OverWorld[(int)world.ActualVec.X, (int)world.ActualVec.Y];
                        ScreenManager.Instance.cam.isTransitioning = true;
                        ScreenManager.Instance.cam.wait = true;
                    }
                    if (position.Y < ScreenManager.Instance.cam.recCamera().Y)
                    {
                        world.ActualVec.X--;
                        world.currentlay = world.OverWorld[(int)world.ActualVec.X, (int)world.ActualVec.Y];
                        ScreenManager.Instance.cam.isTransitioning = true;
                        ScreenManager.Instance.cam.wait = true;
                    }
                }
                catch (Exception e) { }
            }
           }
                
       // }
        
        private void getCurrentAnim()
        {
            if (direction == Direction.down)
                ActualAnimation = getAnimation("stilldown");
            if (direction == Direction.up)
                ActualAnimation = getAnimation("stillup");
            if (direction == Direction.left)
                ActualAnimation = getAnimation("stillleft");
            if (direction == Direction.right)
                ActualAnimation = getAnimation("stillright");
        }
    public Rectangle PlayerMoveRec()
        {
            return new Rectangle((int)position.X+4, (int)position.Y + 8, 9, 8);
        }
        public bool MoveCollision(Vector2 position,WorldScreen screen)
        {
           foreach (Tile t in screen.currentlay.Tiles)
            {
               if(t.type==Tile.Type.solid)
                if (t.rectangle.Intersects(new Rectangle((int)position.X+4,(int)position.Y+8,9,8)))
                {
                    return true;
                }
            }
            return false;
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

        public void MoveDown(WorldScreen screen)
        {
            action = Action.walk;
            direction = Direction.down;
            ActualAnimation = getAnimation("rundown");
            if (!MoveCollision(new Vector2(position.X,position.Y+speed),screen ))
            {
                    position.Y += speed;
            }
        }

        public void MoveUp(WorldScreen screen)
        {
            action = Action.walk;
            direction = Direction.up;
            ActualAnimation = getAnimation("runup");
            if (!MoveCollision(new Vector2(position.X, position.Y - speed), screen))
            {
                    position.Y -= speed;
            }
        }

        public void MoveLeft(WorldScreen screen)
        {
            action = Action.walk;
            direction = Direction.left;
            ActualAnimation = getAnimation("runleft");
            if (!MoveCollision(new Vector2(position.X - speed, position.Y), screen))
            {
                    position.X -= speed;
            }
        }
        public void MoveRight(WorldScreen screen)
        {
            action = Action.walk;
            direction = Direction.right;
            ActualAnimation = getAnimation("runright");
            if (!MoveCollision(new Vector2(position.X + speed, position.Y), screen))
            {
                    position.X += speed;
            }
        }

        public void draw(SpriteBatch sprite)
        {
            ActualAnimation.draw(sprite, position);
            if(Global.Collisions)
            {
                sprite.Draw(collisiontex, new Vector2(this.PlayerMoveRec().X,this.PlayerMoveRec().Y),  new Rectangle(96, 0, 9, 8)     , Color.White * 0.9f);
            }
        }

        private enum Action
        {
            still = 0,
            walk = 1,
            attack = 2
        }

        private enum Direction
        {
            down = 0,
            up = 1,
            left = 2,
            right = 3
        }
    }
}