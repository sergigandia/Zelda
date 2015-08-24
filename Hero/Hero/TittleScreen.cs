using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hero
{
    class TittleScreen : GameScreen
    {
        private MenuManager menuManager;
        private Image back;
        public TittleScreen()
        {
          menuManager = new MenuManager();   
        }
        public override void Draw(SpriteBatch sprite)
        {
            base.Draw(sprite);
            back.draw(sprite);
            menuManager.draw(sprite);
            
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            back.update(time);
            menuManager.update(time);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            menuManager.LoadContent("tittle");
            back = new Image("tittle", new Vector2(
            0, 0), new Rectangle(3,4,256,240));
            back.isActive = true;
            back.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            menuManager.UnloadContent();
           // back.UnLoadContent();
        }
    }
}
