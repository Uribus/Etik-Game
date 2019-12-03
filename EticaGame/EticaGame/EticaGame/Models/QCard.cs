using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class QCard : Card
    {
        string Tema;
        public string Pregunta;
        public string Correcta;
        public string C1, C2;
        public QCard(string pregunta, string tema, string correct, string quest1, string quest2) : base(pregunta, tema)
        {
            this.Pregunta = pregunta;
            this.Tema = tema;
            this.Correcta = correct;
            this.C1 = quest1;
            this.C2 = quest2;
        }
        
        public string GetTema() 
        {
            return this.Tema;
        }
        public string GetPregunta()
        {
            return this.Pregunta;
        }
        public string GetRespuesta()
        {
            return this.Correcta;
        }
        public string GetR1() 
        {
            return this.C1;
        }
        public string GetR2()
        {
            return this.C2;
        }
        public bool IsRight(string respuestaUsr)
        {
            return (respuestaUsr.Equals(Correcta, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
