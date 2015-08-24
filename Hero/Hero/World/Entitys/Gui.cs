using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SwordSlayerREWork;

namespace Hero.World.Entitys
{
    class Gui
    {
        private Texture2D texture;
        private Texture2D items;
        public Gui()
        {
            
        }

        public void LoadContent()
        {
            texture = ScreenManager.Instance.Content.Load<Texture2D>("gui");
            items = ScreenManager.Instance.Content.Load<Texture2D>("items");
        }

        public void update(GameTime time)
        {
            
        }
        public void drawlife(SpriteBatch sprite,WorldScreen screen)
        {
            if (screen.player.health > 0)
            {
                for (int i = 0; i < screen.player.totalhealth / 2; i++)
                {
                    sprite.Draw(items, new Vector2((175 + (i * 8)) * Global.zoom, 50 * Global.zoom), new Rectangle(16, 0, 7, 8), Color.White, 0f, Vector2.Zero, Global.zoom, SpriteEffects.None, 1f);
                }
                if (screen.player.health % 2 == 0)
                {
                    for (int i = 0; i < screen.player.health / 2; i++)
                    {
                        sprite.Draw(items, new Vector2((175 + (i * 8)) * Global.zoom, 50 * Global.zoom), new Rectangle(0, 0, 7, 8), Color.White, 0f, Vector2.Zero, Global.zoom, SpriteEffects.None, 1f);
                    }
                }
                else
                {
                    int j = 0;
                    for (int i = 0; i < (screen.player.health-1) / 2; i++)
                    {
                        sprite.Draw(items, new Vector2((175 + (i * 8)) * Global.zoom, 50 * Global.zoom), new Rectangle(0, 0, 7, 8), Color.White, 0f, Vector2.Zero, Global.zoom, SpriteEffects.None, 1f);
                        j = i;
                    }
                    sprite.Draw(items, new Vector2((175 + ((j+1) * 8)) * Global.zoom, 50 * Global.zoom), new Rectangle(8, 0, 4, 8), Color.White, 0f, Vector2.Zero, Global.zoom, SpriteEffects.None, 1f);
                }
            }
        }
        public void draw(SpriteBatch sprite,Camera cam,WorldScreen screen)
        {
            sprite.End();
            sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);
            sprite.Draw(texture,new Vector2(0,0),new Rectangle(0,0,texture.Width,texture.Height),Color.White,0f,Vector2.Zero,Global.zoom,SpriteEffects.None,1f);
            drawlife(sprite,screen);
            sprite.End();
            sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null,cam.Transform);
        }
    }
}
