using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using SwordSlayerREWork;

namespace Hero
{
    public static class Global
    {
        public static bool Collisions = false;
        public static Texture2D fontTex;
        public static Camera cam;
        public static Texture2D enemytex;
        public static float zoom=3;
        public static Keys A, B,Start, Select,Right,Left,Down,Up;

    }
}
