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
        public string C0, C1, C2, C3;
        public QCard(string pregunta, string tema, string quest0, string quest1, string quest2, string quest3, string correct) : base(pregunta, tema)
        {
            this.Pregunta = pregunta;
            this.Tema = tema;
            this.Correcta = correct;
            this.C0 = quest0;
            this.C1 = quest1;
            this.C2 = quest2;
            this.C3 = quest3;
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
        public string GetR0()
        {
            return this.C0;
        }
        public string GetR1() 
        {
            return this.C1;
        }
        public string GetR2()
        {
            return this.C2;
        }
        public string GetR3()
        {
            return this.C3;
        }
        public bool IsRight(string respuestaUsr)
        {
            return (respuestaUsr.Equals(Correcta, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
