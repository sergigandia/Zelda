using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Hero
{
    public class Polygon
    {
        private List<Point> points;

        public Polygon(List<Point> points)
        {
            this.points = points;
        }
    }
}
