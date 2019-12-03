using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class Card
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Card(string t, string st)
        {
            this.Title = t;
            this.Subtitle = st;
        }
    }
}
