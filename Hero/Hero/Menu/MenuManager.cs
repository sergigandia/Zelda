using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hero
{
    public class MenuManager
    {
        private readonly Menu menu;
        public bool isTransitioning { get; set; }
        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        public void menu_OnMenuChange(Object sender, EventArgs args)
        {
            menu.unloadContent();
            menu.LoadContent();
        }

        public void LoadContent(string MenuPath)
        {
            if (MenuPath != string.Empty)
                menu.ID = MenuPath;
        }

        public void UnloadContent()
        {
            menu.unloadContent();
        }

        public void update(GameTime time)
        {
            menu.update(time);
            if ((InputManager.Instance.keyPressed(Keys.Enter) || InputManager.Instance.keyPressed(Keys.Z))&&!isTransitioning)
            {
                isTransitioning = true;
                if (menu.Items[menu.ItemNumber].LinkType == "Screen")
                {
                    ScreenManager.Instance.ChangeScreen(menu.Items[menu.ItemNumber].LinkId);
                }
                else if (menu.Items[menu.ItemNumber].LinkType == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        public void draw(SpriteBatch sprite)
        {
            menu.draw(sprite);
        }

    }
}