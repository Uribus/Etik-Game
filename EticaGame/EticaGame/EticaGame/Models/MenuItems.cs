using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EticaGame.Models
{
    public class MenuItems
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Color BackColor { get; set; }
        public Type Target { get; set; }

        public MenuItems(string a, string b, Color c, Type t)
        {
            this.Title = a;
            this.Icon = b;
            this.BackColor = c;
            this.Target = t;
        }
    }
}
