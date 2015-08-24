using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero.World.Items
{
    class Rupee : Item
    {
        public Rupee(Vector2 position) : base(position)
        {
            active = true;
            LoadContent();
        }
        public override void LoadContent()
        {
            base.LoadContent();
             List<Rectangle> rec = new List<Rectangle>();
            rec.Add(new Rectangle(72,0,8,16));
             rec.Add(new Rectangle(72,16,8,16));
            ActualAnimation=new Entitys.SpriteManager("Rupee",texture,100f,rec);
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
