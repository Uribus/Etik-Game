using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    class Team
    {
        public string Name { get; set; }
        public int Miembros { get; set; }
        public int Aciertos { get; set; }
        public int Fallos { get; set; }

        public Team(string name, int members) 
        {
            this.Name = name;
            this.Miembros = members;
            this.Aciertos = 0;
            this.Fallos = 0;
        }
    }
}
