using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    class SingleAnswerCard<CType> : QCard<CType>
    {
        string RespuestaCorrecta;
        public SingleAnswerCard (string pregunta, string respuesta, CType tema) : base(pregunta, tema)
        {
            RespuestaCorrecta = respuesta;
        }

        public bool IsRight(string respuestaUsr)
        {
            return (respuestaUsr.Equals(RespuestaCorrecta, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
