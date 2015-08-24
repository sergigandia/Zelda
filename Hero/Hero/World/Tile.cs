using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Hero.World
{

    public class Tile
    {
        public enum Type
        {
          air=0,
           solid=1,
            rightd=2,
            leftd=3,
            invisibol=4

        }
        public Polygon polygon { get; private set; }
        public Type type { get; private set; }
        public Rectangle rectangle { get; private set; }

        public Tile(Type type, Rectangle rectangle)
        {
            this.type = type;
            this.rectangle = rectangle;
        }
        public Tile(Type type, Rectangle rectangle, Polygon polygon)
        {
            this.type = type;
            this.rectangle = rectangle;
            this.polygon = polygon;
        }
    }
}
