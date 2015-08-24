using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hero
{
    public class MenuItem
    {
        public MenuItem(string name)
        {
            this.name = name;
        }

        public string LinkType,LinkId;
        public bool active { get; set; }
        public String name { get; private set; }
        public List<MenuItem> SubMenuItems;
        public void addSubmenu(string name)
        {
            SubMenuItems.Add(new MenuItem(name));
        }

    }
}
