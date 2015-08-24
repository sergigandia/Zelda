using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hero.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;
using Hero.World.Entitys.Enemys;
using Hero.World.Items;

namespace Hero
{
   public class Layer
    {
        
        public TmxMap map;
       public  Vector2 position;
        public List<TmxMap> maps;
        public string mapstring;
        private string tilesets;
        public Texture2D tileset,collisiontex;
        public List<Tile> Tiles;
        public List<Enemy> enemys;
        public List<Item> items;
        public Layer(string mapstring,string tilesets)
        {
      //      this.position = position;
      //      this.position.Y += 640;
            this.mapstring = mapstring;
            this.tilesets = tilesets;
        }
       public void Setposition( Vector2 position)
        {
            this.position = position;
          //  this.position.Y += 640;
        }
        public void LoadContent(WorldScreen screen)
        {
            map = new TmxMap("Content/maps/" +mapstring+".tmx");
            Console.WriteLine("Content/maps/" + mapstring + ".tmx");
            tileset = ScreenManager.Instance.Content.Load<Texture2D>("tileset/"+tilesets);
            collisiontex= ScreenManager.Instance.Content.Load<Texture2D>("tileset/kind");
            Tiles = new List<Tile>();
            Polygon d=null;
         List< Point> lite= new List<Point>();

         enemys = new List<Enemy>();
         items = new List<Item>();
            for (var i = 0; i < map.Layers[1].Tiles.Count; i++)
            {
                Tile.Type p=Tile.Type.air;
                int id = map.Layers[1].Tiles[i].Gid;
                if (id == 172)
                {
                    enemys.Add(new Hero.World.Entitys.Enemys.Octorock(new Vector2((int)position.X + map.Layers[1].Tiles[i].X * 16, (int)position.Y + map.Layers[1].Tiles[i].Y * 16),i));

                }
                if (id == 164) p = Tile.Type.air;
                if (id == 163) p = Tile.Type.solid;
                if (id == 168) p = Tile.Type.invisibol;
                if (id == 166)
                {
                    p = Tile.Type.leftd;
                   lite = new List<Point>();
                    lite.Add(new Point(map.Layers[1].Tiles[i].X * 16, map.Layers[1].Tiles[i].Y * 16));
                    lite.Add(new Point((map.Layers[1].Tiles[i].X * 16)+16, map.Layers[1].Tiles[i].Y * 16));
                    lite.Add(new Point((map.Layers[1].Tiles[i].X * 16) +16, (map.Layers[1].Tiles[i].Y * 16)+16));
                    d= new Polygon(lite);
                }
                if (id == 165)
                {
                    p = Tile.Type.rightd;
                   lite = new List<Point>();
                    lite.Add(new Point(map.Layers[1].Tiles[i].X * 16, map.Layers[1].Tiles[i].Y * 16));
                    lite.Add(new Point((map.Layers[1].Tiles[i].X * 16) + 16, map.Layers[1].Tiles[i].Y * 16));
                    lite.Add(new Point((map.Layers[1].Tiles[i].X * 16), (map.Layers[1].Tiles[i].Y * 16) + 16));
                                 d= new Polygon(lite);
                }
                if (d == null)
                {
                    Tile t = new Tile(p,
                        new Rectangle((int)position.X+map.Layers[1].Tiles[i].X * 16, (int)position.Y + map.Layers[1].Tiles[i].Y * 16, 16, 16));
                    Tiles.Add(t);
                }
                else
                {
                    Tile t = new Tile(p,
                     new Rectangle((int)position.X + map.Layers[1].Tiles[i].X * 16, (int)position.Y+ map.Layers[1].Tiles[i].Y * 16, 16, 16), d);
                    Tiles.Add(t);  
                }
                lite.Clear();
                d = null;
                //       map.Layers[0].Tiles[i].Gid
            }
             foreach (Enemy e in enemys)
             {
                 e.LoadContent(screen);
             }
        }
        public void update(GameTime time,WorldScreen screen)
        {
           foreach (Enemy e in enemys)
           {
               e.update(time,screen);
           }
            foreach(Item e in items)
            {
                e.Update(time);
            }
        }
        public Rectangle getTile(int id)
        {
            int numcol = tileset.Width / (16 + 1) - 1;

            var math = id - ((numcol + 1) * ((id / numcol)));
            var res = math * 17 + 1;
            return new Rectangle(res - 17, (((id / numcol) * 17) + 1), 16, 16);
        }
       public Rectangle rec(int num)
   {
           switch (num)
           {
                          case 0: 
       return new Rectangle(0,0,16,16);
           
               case 1: 
       return new Rectangle(16,0,16,16);
               case 2:
       return new Rectangle(96, 0, 10, 8);         
       }
       return new Rectangle(0,0,16,16);
   }
       public void draw(SpriteBatch sprite, WorldScreen screen)
       {

               for (var i = 0; i < map.Layers[0].Tiles.Count; i++)
               {
                   sprite.Draw(tileset, new Rectangle((int)position.X + map.Layers[0].Tiles[i].X * 16, (int)position.Y + map.Layers[0].Tiles[i].Y * 16, 16, 16), getTile(map.Layers[0].Tiles[i].Gid), Color.White);

               }

               if (Global.Collisions)
               {
                   foreach (Tile ti in Tiles)
                   {
                       if (ti.type == Tile.Type.solid)
                           sprite.Draw(collisiontex, ti.rectangle, rec(30), Color.White * 0.5f);
                       if (ti.type == Tile.Type.air)
                       {
                           //    sprite.Draw(collisiontex, ti.rectangle, rec(1), Color.White * 0.5f);
                       }


                   }
               }
                       foreach(Enemy e in enemys)
                       {
                           e.draw(sprite,screen);
                       }
           foreach(Item e in items)
           {
               e.Draw(sprite);
           }
           }

           

       
        


        internal void UnloadContent()
        {
         //   ScreenManager.Instance.Content.Dispose(map);
        }
    }
}
