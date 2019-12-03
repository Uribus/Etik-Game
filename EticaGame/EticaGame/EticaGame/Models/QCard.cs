using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class QCard
    {
        string Tema;
        public string Pregunta;
         
        public QCard(string pregunta, string tema) 
        {
            this.Pregunta = pregunta;
            this.Tema = tema;
        }
        
        public string GetTema() 
        {
            return this.Tema;
        }
        public string GetPregunta()
        {
            return this.Pregunta;
        }
    }
}
