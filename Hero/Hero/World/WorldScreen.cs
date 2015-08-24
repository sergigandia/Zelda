using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Hero.World.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;
using SwordSlayerREWork;
using Hero.World.Entitys.Enemys;
using Hero.World.Items;
namespace Hero
{
   public class WorldScreen : GameScreen
    {
        public Player player;
        private Gui gui;
        public Layer currentlay;
        public Layer OldLayer;
        public Layer map1, map2, map3, map4,map5,map6,map7,map8,map9,map10,map11,map12,map13,map14,map15,map16,map17,map18,map19,map20,map21,map22,map23,map24,map25,map26,map27,map28,map29,map30,map31,map32,map33,map34,map35,map36;
        public Layer[,] OverWorld;
        public Layer OldMap;
        public Layer Actual;
        public Vector2 ActualVec;
        public bool Trans;
       public WorldScreen()
        {
            gui=new Gui();
            ScreenManager.Instance.cam.isInGame = true;
            map13 = new Layer("map13", "tiles1");
           map1 = new Layer("map1", "tiles1");
            map2 = new Layer("map2", "tiles1");
            map3 = new Layer("map3", "tiles1");
            map4 = new Layer("map4", "tiles1");
            map5 = new Layer("map5", "tiles1");
            map6 = new Layer("map6", "tiles1");
            map7 = new Layer("map7", "tiles1");
            map8 = new Layer("map8", "tiles1"); //256,176 all screens.
            map9 = new Layer("map9", "tiles1");
          //  map10 = new Layer("maptest", "tiles1");
         //   map11 = new Layer("map11", "tiles1");
         //   map12 = new Layer("map12", "tiles1");

            map14 = new Layer("map14", "tiles1");
           map15 = new Layer("map15", "tiles1");
           map16 = new Layer("map16", "tiles1");
           map17 = new Layer("map17", "tiles1");
           map18 = new Layer("map18", "tiles1");
           map19 = new Layer("map19", "tiles1");
           map20 = new Layer("map20", "tiles1");
           map21 = new Layer("map21", "tiles1");
           map22 = new Layer("map22", "tiles1");
           map23 = new Layer("map23", "tiles1");
           map24 = new Layer("map24", "tiles1");
           map25 = new Layer("map25", "tiles1");
           map26 = new Layer("map26", "tiles1");
           map27 = new Layer("map27", "tiles1");
           map28 = new Layer("map28", "tiles1");
           map29 = new Layer("map29", "tiles1");
           map30 = new Layer("map30", "tiles1");
           map31 = new Layer("map31", "tiles1");
           map32 = new Layer("map32", "tiles1");
           map33 = new Layer("map33", "tiles1");
           map34 = new Layer("map34", "tiles1");
           map35 = new Layer("map35", "tiles1");
           map36 = new Layer("map36", "tiles1");
         //   Console.WriteLine("MAP 13");

     //       Console.WriteLine(map13.map.Layers[0].Name);
             OverWorld = new Layer[,]{
                                  {map7,map8,map9,map15,map16,map31,map32,map33,map34,map35,map36},
                                  {map6,map3,map2,map14,map17,map25,map26,map27,map28,map29,map30},
                                  {map5,map4,map1,map13,map18,map19,map20,map21,map22,map23,map24}};
             for (int y = 0; y < OverWorld.GetLongLength(0); y++)
             {
                 for (int x = 0; x < OverWorld.GetLongLength(1); x++)
                 {
                   OverWorld[y,x].Setposition(new Vector2(256*x,82+176*y));
                 }
             }
            if (currentlay == null)
            {
               Actual = OverWorld[2, 2];
                OldMap = Actual;
              ActualVec = new Vector2(2, 2);
                currentlay = Actual;
            }
            player = new Player(this);
            Console.WriteLine(currentlay.position);
        }
        public override void LoadContent()
        {
            base.LoadContent();
            player.LoadContent();
            gui.LoadContent();
            currentlay.LoadContent(this);
      foreach (Layer l in OverWorld)
      {
          l.LoadContent(this);
      }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            currentlay.UnloadContent();
        }
        public void ChangeMap(GameTime time)
        {
            Trans = true;
            OldLayer = currentlay;
            currentlay = null;
            currentlay = new Layer(Actual.mapstring, "tiles1");
            currentlay.LoadContent(this);
            Trans = false;
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            ScreenManager.Instance.cam.UpdateView(this);
            if(OldMap!= Actual)
            {
              //  ChangeMap(time);
            }
          if (!ScreenManager.Instance.cam.isTransitioning)
           {
                player.update(time, this);
                currentlay.update(time,this);
              gui.update(time);

            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
          //  currentlay.draw(spriteBatch);
            foreach(Layer l in OverWorld)
            {
                l.draw(spriteBatch,this);
            }
            player.draw(spriteBatch);
            gui.draw(spriteBatch,ScreenManager.Instance.cam,this);
        }

        internal void genItem(Enemy.Kind kind,Vector2 position,GameTime time)
        {
            int seed = unchecked(System.DateTime.Now.Millisecond);
            Random ge = new Random(1311+seed);
            if (kind == Enemy.Kind.A)
            {
                var t = ge.Next(0, 10);
                currentlay.items.Add(new Angel(position));
              //  if (t == 1 || t == 3 || t == 8 ) currentlay.items.Add(new Rupee(position));
              //  else if (t == 2 || t == 6 || t == 7 || t == 10) currentlay.items.Add(new Hearth(position));
            }
        }
    }
}
