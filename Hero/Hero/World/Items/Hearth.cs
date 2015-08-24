using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Items
{
    class Hearth : Item
    {
            public Hearth(Vector2 position) : base(position)
        {
            LoadContent();
         }
           public override void LoadContent()
        {
            base.LoadContent();
             List<Rectangle> rec = new List<Rectangle>();
            rec.Add(new Rectangle(0,0,7,8));
             rec.Add(new Rectangle(0,8,7,8));
            ActualAnimation=new Entitys.SpriteManager("Hearth",texture,100f,rec);
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {    
           base.Update(time);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite)
        {
            base.Draw(sprite);
        }
    
    }
}
