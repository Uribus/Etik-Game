using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    class QCard<CType>
    {
        CType Tema;
        public string Pregunta;
         
        public QCard(string pregunta, CType tema) 
        {
            this.Pregunta = pregunta;
            this.Tema = tema;
        }
        
        public CType GetTema() 
        {
            return this.Tema;
        }
        public string GetPregunta()
        {
            return this.Pregunta;
        }
    }
}
