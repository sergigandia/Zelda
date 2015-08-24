using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hero
{
    public class Menu
    {
        public string Axis;
        public string Effects;
        private string id;
        public int ItemNumber { get; private set; }
        public List<MenuItem> Items;
        public EventHandler OnMenuChange;

        public Menu()
        {
            id = string.Empty;
            ItemNumber = 0;
            Effects = string.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnMenuChange(this, null);
            }
        }

        private void AligMenuItems()
        {
            var dimensions = Vector2.Zero;
            //      foreach(MenuItem item in Items)
            //        dimensions+= new Vector2(item.);
        }

        public void LoadContent()
        {
            AligMenuItems();
            var newgame = new MenuItem("new game");
            var continues = new MenuItem("continue");
            var options = new MenuItem("options");
            var exit = new MenuItem("exit");
            Items.Add(newgame);
            Items[0].LinkId = "WorldScreen";
            Items[0].LinkType = "Screen";
            Items.Add(continues);
            Items.Add(options);
            Items.Add(exit);
            Items[3].LinkType = "Exit";
        }

        public void unloadContent()
        {
        }

        public void update(GameTime time)
        {
            if (InputManager.Instance.keyPressed(Keys.Down))
            {
                ItemNumber++;
            }
            else if (InputManager.Instance.keyPressed(Keys.Up))
            {
                ItemNumber--;
            }
            if (ItemNumber < 0)
                ItemNumber = 0;
            else if (ItemNumber > Items.Count - 1)
            {
                ItemNumber = Items.Count - 1;
            }
            for (var i = 0; i < Items.Count; i++)
            {
                if (i == ItemNumber)
                {
                    Items[i].active = true;
                }
                else
                {
                    Items[i].active = false;
                }
            }
        }

        internal void draw(SpriteBatch sprite)
        {
            var i = 1;
            foreach (var item in Items)
            {
                if (item.active)
                    ScreenManager.Instance.font.DrawString(sprite, item.name, new Vector2(105, 125 + 25*i), Color.White);
                else
                {
                    ScreenManager.Instance.font.DrawString(sprite, item.name, new Vector2(105, 125 + 25*i), Color.Gray);
                }
                i++;
            }
        }
    }
}