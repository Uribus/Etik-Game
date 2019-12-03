using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class MultiAnswerCard : QCard
    {
        string RespuestaCorrecta, Respuesta2, Respuesta3;
        public MultiAnswerCard(string pregunta, string respuesta, string res2, string res3, string tema) : base(pregunta, tema)
        {
            RespuestaCorrecta = respuesta;
            Respuesta2 = res2;
            Respuesta3 = res3;
        }

        public bool IsRight(string respuestaUsr)
        {
            return (respuestaUsr.Equals(RespuestaCorrecta, StringComparison.InvariantCultureIgnoreCase));
        }
        public string GetRCorrecta()
        {
            return RespuestaCorrecta;
        }
        public string GetR2()
        {
            return Respuesta2;
        }
        public string GetR3()
        {
            return Respuesta3;
        }
    }
}
