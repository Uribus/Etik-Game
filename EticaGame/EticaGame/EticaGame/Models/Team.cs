using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class Team
    {
        public string Name { get; set; }
        public string Aciertos { get; set; }
        public string Fallos { get; set; }

        public Team(int id) 
        {
            string v = id.ToString();
            this.Name = "Equipo " + v;
            this.Aciertos = "Aciertos: " + "0";
            this.Fallos = "Fallos: " + "0";
        }

    }
}
