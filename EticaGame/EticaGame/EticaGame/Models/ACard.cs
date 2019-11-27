using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    class ACard
    {
        string Title, Explica;
        public ACard(string titulo, string explica)
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
