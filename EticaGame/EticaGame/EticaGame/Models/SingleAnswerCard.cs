using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class SingleAnswerCard : QCard
    {
        string RespuestaCorrecta;
        public SingleAnswerCard (string pregunta, string respuesta, string tema) : base(pregunta, tema)
        {
            RespuestaCorrecta = respuesta;
        }

        public bool IsRight(string respuestaUsr)
        {
            return (respuestaUsr.Equals(RespuestaCorrecta, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
