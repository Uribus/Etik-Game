using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class ACard : Card
    {
        string Title, Explica;
        public ACard(string titulo, string explica) : base(titulo, explica)
        {
            Title = titulo;
            Explica = explica;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetExplica()
        {
            return Explica;
        }
    }
}
